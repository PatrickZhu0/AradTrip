using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020048CA RID: 18634
public class MediaPlayerCtrl : MonoBehaviour
{
	// Token: 0x0601ACE1 RID: 109793
	[DllImport("BlueDoveMediaRender")]
	private static extern void InitNDK();

	// Token: 0x0601ACE2 RID: 109794
	[DllImport("BlueDoveMediaRender")]
	private static extern IntPtr EasyMovieTextureRender();

	// Token: 0x0601ACE3 RID: 109795 RVA: 0x0083EBB4 File Offset: 0x0083CFB4
	private void Awake()
	{
		if (SystemInfo.deviceModel.Contains("rockchip"))
		{
			this.m_bSupportRockchip = true;
		}
		else
		{
			this.m_bSupportRockchip = false;
		}
		if (SystemInfo.graphicsMultiThreaded)
		{
			MediaPlayerCtrl.InitNDK();
		}
		this.m_iAndroidMgrID = this.Call_InitNDK();
		this.Call_SetUnityActivity();
	}

	// Token: 0x0601ACE4 RID: 109796 RVA: 0x0083EC09 File Offset: 0x0083D009
	private void Start()
	{
		if (Application.dataPath.Contains(".obb"))
		{
			this.Call_SetSplitOBB(true, Application.dataPath);
		}
		else
		{
			this.Call_SetSplitOBB(false, null);
		}
		this.m_bInit = true;
	}

	// Token: 0x0601ACE5 RID: 109797 RVA: 0x0083EC3F File Offset: 0x0083D03F
	private void OnApplicationQuit()
	{
	}

	// Token: 0x0601ACE6 RID: 109798 RVA: 0x0083EC41 File Offset: 0x0083D041
	private void OnDisable()
	{
		if (this.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
		{
			this.Pause();
		}
	}

	// Token: 0x0601ACE7 RID: 109799 RVA: 0x0083EC55 File Offset: 0x0083D055
	private void OnEnable()
	{
		if (this.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED)
		{
			this.Play();
		}
	}

	// Token: 0x0601ACE8 RID: 109800 RVA: 0x0083EC6C File Offset: 0x0083D06C
	private void Update()
	{
		if (string.IsNullOrEmpty(this.m_strFileName))
		{
			return;
		}
		if (this.checkNewActions)
		{
			this.checkNewActions = false;
			this.CheckThreading();
		}
		if (!this.m_bFirst)
		{
			string text = this.m_strFileName.Trim();
			if (this.m_bSupportRockchip)
			{
				this.Call_SetRockchip(this.m_bSupportRockchip);
				if (text.Contains("://"))
				{
					this.Call_Load(text, 0);
				}
				else
				{
					base.StartCoroutine(this.CopyStreamingAssetVideoAndLoad(text));
				}
			}
			else
			{
				this.Call_Load(text, 0);
			}
			this.Call_SetLooping(this.m_bLoop);
			this.m_bFirst = true;
		}
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED)
		{
			if (!this.m_bCheckFBO)
			{
				if (this.Call_GetVideoWidth() <= 0 || this.Call_GetVideoHeight() <= 0)
				{
					return;
				}
				this.m_iWidth = this.Call_GetVideoWidth();
				this.m_iHeight = this.Call_GetVideoHeight();
				this.Resize();
				if (this.m_VideoTexture != null)
				{
					if (this.m_VideoTextureDummy != null)
					{
						Object.Destroy(this.m_VideoTextureDummy);
						this.m_VideoTextureDummy = null;
					}
					this.m_VideoTextureDummy = this.m_VideoTexture;
					this.m_VideoTexture = null;
				}
				if (this.m_bSupportRockchip)
				{
					this.m_VideoTexture = new Texture2D(this.Call_GetVideoWidth(), this.Call_GetVideoHeight(), 7, false);
				}
				else
				{
					this.m_VideoTexture = new Texture2D(this.Call_GetVideoWidth(), this.Call_GetVideoHeight(), 4, false);
				}
				this.m_VideoTexture.filterMode = 1;
				this.m_VideoTexture.wrapMode = 1;
				this.m_texPtr = this.m_VideoTexture.GetNativeTexturePtr();
				this.Call_SetUnityTexture((int)this.m_texPtr);
				this.Call_SetWindowSize();
				this.m_bCheckFBO = true;
				if (this.OnResize != null)
				{
					this.OnResize();
				}
			}
			else if (this.Call_GetVideoWidth() != this.m_iWidth || this.Call_GetVideoHeight() != this.m_iHeight)
			{
				this.m_iWidth = this.Call_GetVideoWidth();
				this.m_iHeight = this.Call_GetVideoHeight();
				if (this.OnResize != null)
				{
					this.OnResize();
				}
				this.ResizeTexture();
			}
			this.Call_UpdateVideoTexture();
			this.m_iCurrentSeekPosition = this.Call_GetSeekPosition();
		}
		if (this.m_CurrentState != this.Call_GetStatus())
		{
			this.m_CurrentState = this.Call_GetStatus();
			if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY)
			{
				if (this.OnReady != null)
				{
					this.OnReady();
				}
				if (this.m_bAutoPlay)
				{
					this.Call_Play(0);
				}
				if (this.m_bReadyPlay)
				{
					this.Call_Play(0);
					this.m_bReadyPlay = false;
				}
				this.SetVolume(this.m_fVolume);
			}
			else if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
			{
				if (this.OnEnd != null)
				{
					this.OnEnd();
				}
				if (this.m_bLoop)
				{
					this.Call_Play(0);
				}
			}
			else if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.ERROR)
			{
				this.OnError((MediaPlayerCtrl.MEDIAPLAYER_ERROR)this.Call_GetError(), (MediaPlayerCtrl.MEDIAPLAYER_ERROR)this.Call_GetErrorExtra());
			}
		}
		GL.InvalidateState();
	}

	// Token: 0x0601ACE9 RID: 109801 RVA: 0x0083EFA4 File Offset: 0x0083D3A4
	public void DeleteVideoTexture()
	{
		if (this.m_VideoTextureDummy != null)
		{
			Object.Destroy(this.m_VideoTextureDummy);
			this.m_VideoTextureDummy = null;
		}
		if (this.m_VideoTexture != null)
		{
			Object.Destroy(this.m_VideoTexture);
			this.m_VideoTexture = null;
		}
	}

	// Token: 0x0601ACEA RID: 109802 RVA: 0x0083EFF8 File Offset: 0x0083D3F8
	public void ResizeTexture()
	{
		Debug.Log(string.Concat(new object[]
		{
			"ResizeTexture ",
			this.m_iWidth,
			" ",
			this.m_iHeight
		}));
		if (this.m_iWidth == 0 || this.m_iHeight == 0)
		{
			return;
		}
		if (this.m_VideoTexture != null)
		{
			if (this.m_VideoTextureDummy != null)
			{
				Object.Destroy(this.m_VideoTextureDummy);
				this.m_VideoTextureDummy = null;
			}
			this.m_VideoTextureDummy = this.m_VideoTexture;
			this.m_VideoTexture = null;
		}
		if (this.m_bSupportRockchip)
		{
			this.m_VideoTexture = new Texture2D(this.Call_GetVideoWidth(), this.Call_GetVideoHeight(), 7, false);
		}
		else
		{
			this.m_VideoTexture = new Texture2D(this.Call_GetVideoWidth(), this.Call_GetVideoHeight(), 4, false);
		}
		this.m_VideoTexture.filterMode = 1;
		this.m_VideoTexture.wrapMode = 1;
		this.m_texPtr = this.m_VideoTexture.GetNativeTexturePtr();
		this.Call_SetUnityTexture((int)this.m_texPtr);
		this.Call_SetWindowSize();
	}

	// Token: 0x0601ACEB RID: 109803 RVA: 0x0083F124 File Offset: 0x0083D524
	public void Resize()
	{
		if (this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
		{
			return;
		}
		if (this.Call_GetVideoWidth() <= 0 || this.Call_GetVideoHeight() <= 0)
		{
			return;
		}
		if (this.m_objResize != null)
		{
			int width = Screen.width;
			int height = Screen.height;
			float num = (float)height / (float)width;
			int num2 = this.Call_GetVideoWidth();
			int num3 = this.Call_GetVideoHeight();
			float num4 = (float)num3 / (float)num2;
			float num5 = num / num4;
			for (int i = 0; i < this.m_objResize.Length; i++)
			{
				if (!(this.m_objResize[i] == null))
				{
					if (this.m_bFullScreen)
					{
						this.m_objResize[i].transform.localScale = new Vector3(20f / num, 20f / num, 1f);
						if (num4 < 1f)
						{
							if (num < 1f && num4 > num)
							{
								this.m_objResize[i].transform.localScale *= num5;
							}
							this.m_ScaleValue = MediaPlayerCtrl.MEDIA_SCALE.SCALE_X_TO_Y;
						}
						else
						{
							if (num > 1f)
							{
								if (num4 >= num)
								{
									this.m_objResize[i].transform.localScale *= num5;
								}
							}
							else
							{
								this.m_objResize[i].transform.localScale *= num5;
							}
							this.m_ScaleValue = MediaPlayerCtrl.MEDIA_SCALE.SCALE_X_TO_Y;
						}
					}
					if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_X_TO_Y)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.x, this.m_objResize[i].transform.localScale.x * num4, this.m_objResize[i].transform.localScale.z);
					}
					else if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_X_TO_Y_2)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.x, this.m_objResize[i].transform.localScale.x * num4 / 2f, this.m_objResize[i].transform.localScale.z);
					}
					else if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_X_TO_Z)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.x, this.m_objResize[i].transform.localScale.y, this.m_objResize[i].transform.localScale.x * num4);
					}
					else if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_Y_TO_X)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.y / num4, this.m_objResize[i].transform.localScale.y, this.m_objResize[i].transform.localScale.z);
					}
					else if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_Y_TO_Z)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.x, this.m_objResize[i].transform.localScale.y, this.m_objResize[i].transform.localScale.y / num4);
					}
					else if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_Z_TO_X)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.z * num4, this.m_objResize[i].transform.localScale.y, this.m_objResize[i].transform.localScale.z);
					}
					else if (this.m_ScaleValue == MediaPlayerCtrl.MEDIA_SCALE.SCALE_Z_TO_Y)
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.x, this.m_objResize[i].transform.localScale.z * num4, this.m_objResize[i].transform.localScale.z);
					}
					else
					{
						this.m_objResize[i].transform.localScale = new Vector3(this.m_objResize[i].transform.localScale.x, this.m_objResize[i].transform.localScale.y, this.m_objResize[i].transform.localScale.z);
					}
				}
			}
		}
	}

	// Token: 0x0601ACEC RID: 109804 RVA: 0x0083F698 File Offset: 0x0083DA98
	private void OnError(MediaPlayerCtrl.MEDIAPLAYER_ERROR iCode, MediaPlayerCtrl.MEDIAPLAYER_ERROR iCodeExtra)
	{
		string text = string.Empty;
		if (iCode != MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_UNKNOWN)
		{
			if (iCode != MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_SERVER_DIED)
			{
				if (iCode != MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_NOT_VALID_FOR_PROGRESSIVE_PLAYBACK)
				{
					text = "Unknown error " + iCode;
				}
				else
				{
					text = "MEDIA_ERROR_NOT_VALID_FOR_PROGRESSIVE_PLAYBACK";
				}
			}
			else
			{
				text = "MEDIA_ERROR_SERVER_DIED";
			}
		}
		else
		{
			text = "MEDIA_ERROR_UNKNOWN";
		}
		text += " ";
		switch (iCodeExtra + 1010)
		{
		case (MediaPlayerCtrl.MEDIAPLAYER_ERROR)0:
			text += "MEDIA_ERROR_UNSUPPORTED";
			break;
		default:
			if (iCodeExtra != MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_IO)
			{
				if (iCodeExtra != MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_TIMED_OUT)
				{
					text = "Unknown error " + iCode;
				}
				else
				{
					text += "MEDIA_ERROR_TIMED_OUT";
				}
			}
			else
			{
				text += "MEDIA_ERROR_IO";
			}
			break;
		case (MediaPlayerCtrl.MEDIAPLAYER_ERROR)3:
			text += "MEDIA_ERROR_MALFORMED";
			break;
		}
		Debug.LogError(text);
		if (this.OnVideoError != null)
		{
			this.OnVideoError(iCode, iCodeExtra);
		}
	}

	// Token: 0x0601ACED RID: 109805 RVA: 0x0083F7BC File Offset: 0x0083DBBC
	private void OnDestroy()
	{
		this.Call_UnLoad();
		if (this.m_VideoTextureDummy != null)
		{
			Object.Destroy(this.m_VideoTextureDummy);
			this.m_VideoTextureDummy = null;
		}
		if (this.m_VideoTexture != null)
		{
			Object.Destroy(this.m_VideoTexture);
		}
		this.Call_Destroy();
	}

	// Token: 0x0601ACEE RID: 109806 RVA: 0x0083F814 File Offset: 0x0083DC14
	private void OnApplicationPause(bool bPause)
	{
		Debug.Log("ApplicationPause : " + bPause);
		if (bPause)
		{
			if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED)
			{
				this.m_bPause = true;
			}
			this.Call_Pause();
		}
		else
		{
			this.Call_RePlay();
			if (this.m_bPause)
			{
				this.Call_Pause();
				this.m_bPause = false;
			}
		}
	}

	// Token: 0x0601ACEF RID: 109807 RVA: 0x0083F878 File Offset: 0x0083DC78
	public MediaPlayerCtrl.MEDIAPLAYER_STATE GetCurrentState()
	{
		return this.m_CurrentState;
	}

	// Token: 0x0601ACF0 RID: 109808 RVA: 0x0083F880 File Offset: 0x0083DC80
	public Texture2D GetVideoTexture()
	{
		return this.m_VideoTexture;
	}

	// Token: 0x0601ACF1 RID: 109809 RVA: 0x0083F888 File Offset: 0x0083DC88
	public void Play()
	{
		if (this.m_bStop)
		{
			this.SeekTo(0);
			this.Call_Play(0);
			this.m_bStop = false;
		}
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED)
		{
			this.Call_RePlay();
		}
		else if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
		{
			this.Call_Play(0);
		}
		else if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
		{
			this.m_bReadyPlay = true;
		}
	}

	// Token: 0x0601ACF2 RID: 109810 RVA: 0x0083F90E File Offset: 0x0083DD0E
	public void Stop()
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
		{
			this.Call_Pause();
		}
		this.m_bStop = true;
		this.m_CurrentState = MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED;
		this.m_iCurrentSeekPosition = 0;
	}

	// Token: 0x0601ACF3 RID: 109811 RVA: 0x0083F937 File Offset: 0x0083DD37
	public void Pause()
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
		{
			this.Call_Pause();
			this.m_CurrentState = MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED;
		}
	}

	// Token: 0x0601ACF4 RID: 109812 RVA: 0x0083F954 File Offset: 0x0083DD54
	public void Load(string strFileName)
	{
		if (this.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
		{
			this.UnLoad();
		}
		this.m_bReadyPlay = false;
		this.m_bIsFirstFrameReady = false;
		this.m_bFirst = false;
		this.m_bCheckFBO = false;
		this.m_strFileName = strFileName;
		if (!this.m_bInit)
		{
			return;
		}
		this.m_CurrentState = MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY;
	}

	// Token: 0x0601ACF5 RID: 109813 RVA: 0x0083F9A8 File Offset: 0x0083DDA8
	public void SetVolume(float fVolume)
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED)
		{
			this.m_fVolume = fVolume;
			this.Call_SetVolume(fVolume);
		}
	}

	// Token: 0x0601ACF6 RID: 109814 RVA: 0x0083F9FF File Offset: 0x0083DDFF
	public float GetVolume()
	{
		return this.m_fVolume;
	}

	// Token: 0x0601ACF7 RID: 109815 RVA: 0x0083FA07 File Offset: 0x0083DE07
	public int GetSeekPosition()
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END)
		{
			return this.m_iCurrentSeekPosition;
		}
		return 0;
	}

	// Token: 0x0601ACF8 RID: 109816 RVA: 0x0083FA38 File Offset: 0x0083DE38
	public void SeekTo(int iSeek)
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED)
		{
			this.Call_SetSeekPosition(iSeek);
		}
	}

	// Token: 0x0601ACF9 RID: 109817 RVA: 0x0083FA88 File Offset: 0x0083DE88
	public void SetSpeed(float fSpeed)
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED)
		{
			this.m_fSpeed = fSpeed;
			this.Call_SetSpeed(fSpeed);
		}
	}

	// Token: 0x0601ACFA RID: 109818 RVA: 0x0083FAE0 File Offset: 0x0083DEE0
	public int GetDuration()
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED)
		{
			return this.Call_GetDuration();
		}
		return 0;
	}

	// Token: 0x0601ACFB RID: 109819 RVA: 0x0083FB34 File Offset: 0x0083DF34
	public float GetSeekBarValue()
	{
		if (this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.END && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.READY && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED)
		{
			return 0f;
		}
		if (this.GetDuration() == 0)
		{
			return 0f;
		}
		return (float)this.GetSeekPosition() / (float)this.GetDuration();
	}

	// Token: 0x0601ACFC RID: 109820 RVA: 0x0083FBA4 File Offset: 0x0083DFA4
	public void SetSeekBarValue(float fValue)
	{
		if (this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.END && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.READY && this.m_CurrentState != MediaPlayerCtrl.MEDIAPLAYER_STATE.STOPPED)
		{
			return;
		}
		if (this.GetDuration() == 0)
		{
			return;
		}
		this.SeekTo((int)((float)this.GetDuration() * fValue));
	}

	// Token: 0x0601ACFD RID: 109821 RVA: 0x0083FC0F File Offset: 0x0083E00F
	public int GetCurrentSeekPercent()
	{
		if (this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.PAUSED || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.END || this.m_CurrentState == MediaPlayerCtrl.MEDIAPLAYER_STATE.READY)
		{
			return this.Call_GetCurrentSeekPercent();
		}
		return 0;
	}

	// Token: 0x0601ACFE RID: 109822 RVA: 0x0083FC49 File Offset: 0x0083E049
	public int GetVideoWidth()
	{
		return this.Call_GetVideoWidth();
	}

	// Token: 0x0601ACFF RID: 109823 RVA: 0x0083FC51 File Offset: 0x0083E051
	public int GetVideoHeight()
	{
		return this.Call_GetVideoHeight();
	}

	// Token: 0x0601AD00 RID: 109824 RVA: 0x0083FC59 File Offset: 0x0083E059
	public void UnLoad()
	{
		this.m_bCheckFBO = false;
		this.Call_UnLoad();
		this.m_CurrentState = MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY;
	}

	// Token: 0x0601AD01 RID: 109825 RVA: 0x0083FC6F File Offset: 0x0083E06F
	private AndroidJavaObject GetJavaObject()
	{
		if (this.javaObj == null)
		{
			this.javaObj = new AndroidJavaObject("com.EasyMovieTexture.EasyMovieTexture", new object[0]);
		}
		return this.javaObj;
	}

	// Token: 0x0601AD02 RID: 109826 RVA: 0x0083FC98 File Offset: 0x0083E098
	private void Call_Destroy()
	{
		if (SystemInfo.graphicsMultiThreaded)
		{
			GL.IssuePluginEvent(MediaPlayerCtrl.EasyMovieTextureRender(), 5 + this.m_iAndroidMgrID * 10 + 7000);
		}
		else
		{
			this.GetJavaObject().Call("Destroy", new object[0]);
		}
	}

	// Token: 0x0601AD03 RID: 109827 RVA: 0x0083FCE8 File Offset: 0x0083E0E8
	private void Call_UnLoad()
	{
		if (SystemInfo.graphicsMultiThreaded)
		{
			GL.IssuePluginEvent(MediaPlayerCtrl.EasyMovieTextureRender(), 4 + this.m_iAndroidMgrID * 10 + 7000);
		}
		else
		{
			this.GetJavaObject().Call("UnLoad", new object[0]);
		}
	}

	// Token: 0x0601AD04 RID: 109828 RVA: 0x0083FD38 File Offset: 0x0083E138
	private bool Call_Load(string strFileName, int iSeek)
	{
		if (SystemInfo.graphicsMultiThreaded)
		{
			this.GetJavaObject().Call("NDK_SetFileName", new object[]
			{
				strFileName
			});
			GL.IssuePluginEvent(MediaPlayerCtrl.EasyMovieTextureRender(), 1 + this.m_iAndroidMgrID * 10 + 7000);
			this.Call_SetNotReady();
			return true;
		}
		this.GetJavaObject().Call("NDK_SetFileName", new object[]
		{
			strFileName
		});
		if (this.GetJavaObject().Call<bool>("Load", new object[0]))
		{
			return true;
		}
		this.OnError(MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_UNKNOWN, MediaPlayerCtrl.MEDIAPLAYER_ERROR.MEDIA_ERROR_UNKNOWN);
		return false;
	}

	// Token: 0x0601AD05 RID: 109829 RVA: 0x0083FDCC File Offset: 0x0083E1CC
	private void Call_UpdateVideoTexture()
	{
		if (!this.Call_IsUpdateFrame())
		{
			return;
		}
		if (this.m_VideoTextureDummy != null)
		{
			Object.Destroy(this.m_VideoTextureDummy);
			this.m_VideoTextureDummy = null;
		}
		for (int i = 0; i < this.m_TargetMaterial.Length; i++)
		{
			if (this.m_TargetMaterial[i])
			{
				if (this.m_TargetMaterial[i].GetComponent<MeshRenderer>() != null && this.m_TargetMaterial[i].GetComponent<MeshRenderer>().material.mainTexture != this.m_VideoTexture)
				{
					this.m_TargetMaterial[i].GetComponent<MeshRenderer>().material.mainTexture = this.m_VideoTexture;
				}
				if (this.m_TargetMaterial[i].GetComponent<RawImage>() != null && this.m_TargetMaterial[i].GetComponent<RawImage>().texture != this.m_VideoTexture)
				{
					this.m_TargetMaterial[i].GetComponent<RawImage>().texture = this.m_VideoTexture;
				}
			}
		}
		if (SystemInfo.graphicsMultiThreaded)
		{
			GL.IssuePluginEvent(MediaPlayerCtrl.EasyMovieTextureRender(), 3 + this.m_iAndroidMgrID * 10 + 7000);
		}
		else
		{
			this.GetJavaObject().Call("UpdateVideoTexture", new object[0]);
		}
		if (!this.m_bIsFirstFrameReady)
		{
			this.m_bIsFirstFrameReady = true;
			if (this.OnVideoFirstFrameReady != null)
			{
				this.OnVideoFirstFrameReady();
			}
		}
	}

	// Token: 0x0601AD06 RID: 109830 RVA: 0x0083FF49 File Offset: 0x0083E349
	private void Call_SetVolume(float fVolume)
	{
		this.GetJavaObject().Call("SetVolume", new object[]
		{
			fVolume
		});
	}

	// Token: 0x0601AD07 RID: 109831 RVA: 0x0083FF6A File Offset: 0x0083E36A
	private void Call_SetSeekPosition(int iSeek)
	{
		this.GetJavaObject().Call("SetSeekPosition", new object[]
		{
			iSeek
		});
	}

	// Token: 0x0601AD08 RID: 109832 RVA: 0x0083FF8B File Offset: 0x0083E38B
	private int Call_GetSeekPosition()
	{
		return this.GetJavaObject().Call<int>("GetSeekPosition", new object[0]);
	}

	// Token: 0x0601AD09 RID: 109833 RVA: 0x0083FFA3 File Offset: 0x0083E3A3
	private void Call_Play(int iSeek)
	{
		this.GetJavaObject().Call("Play", new object[]
		{
			iSeek
		});
	}

	// Token: 0x0601AD0A RID: 109834 RVA: 0x0083FFC4 File Offset: 0x0083E3C4
	private void Call_Reset()
	{
		this.GetJavaObject().Call("Reset", new object[0]);
	}

	// Token: 0x0601AD0B RID: 109835 RVA: 0x0083FFDC File Offset: 0x0083E3DC
	private void Call_Stop()
	{
		this.GetJavaObject().Call("Stop", new object[0]);
	}

	// Token: 0x0601AD0C RID: 109836 RVA: 0x0083FFF4 File Offset: 0x0083E3F4
	private void Call_RePlay()
	{
		this.GetJavaObject().Call("RePlay", new object[0]);
	}

	// Token: 0x0601AD0D RID: 109837 RVA: 0x0084000C File Offset: 0x0083E40C
	private void Call_Pause()
	{
		this.GetJavaObject().Call("Pause", new object[0]);
	}

	// Token: 0x0601AD0E RID: 109838 RVA: 0x00840024 File Offset: 0x0083E424
	private int Call_InitNDK()
	{
		return this.GetJavaObject().Call<int>("InitNative", new object[]
		{
			this.GetJavaObject()
		});
	}

	// Token: 0x0601AD0F RID: 109839 RVA: 0x00840045 File Offset: 0x0083E445
	private int Call_GetVideoWidth()
	{
		return this.GetJavaObject().Call<int>("GetVideoWidth", new object[0]);
	}

	// Token: 0x0601AD10 RID: 109840 RVA: 0x0084005D File Offset: 0x0083E45D
	private int Call_GetVideoHeight()
	{
		return this.GetJavaObject().Call<int>("GetVideoHeight", new object[0]);
	}

	// Token: 0x0601AD11 RID: 109841 RVA: 0x00840075 File Offset: 0x0083E475
	private bool Call_IsUpdateFrame()
	{
		return this.GetJavaObject().Call<bool>("IsUpdateFrame", new object[0]);
	}

	// Token: 0x0601AD12 RID: 109842 RVA: 0x0084008D File Offset: 0x0083E48D
	private void Call_SetUnityTexture(int iTextureID)
	{
		this.GetJavaObject().Call("SetUnityTexture", new object[]
		{
			iTextureID
		});
	}

	// Token: 0x0601AD13 RID: 109843 RVA: 0x008400B0 File Offset: 0x0083E4B0
	private void Call_SetWindowSize()
	{
		if (SystemInfo.graphicsMultiThreaded)
		{
			GL.IssuePluginEvent(MediaPlayerCtrl.EasyMovieTextureRender(), 2 + this.m_iAndroidMgrID * 10 + 7000);
		}
		else
		{
			this.GetJavaObject().Call("SetWindowSize", new object[0]);
		}
	}

	// Token: 0x0601AD14 RID: 109844 RVA: 0x008400FD File Offset: 0x0083E4FD
	private void Call_SetLooping(bool bLoop)
	{
		this.GetJavaObject().Call("SetLooping", new object[]
		{
			bLoop
		});
	}

	// Token: 0x0601AD15 RID: 109845 RVA: 0x0084011E File Offset: 0x0083E51E
	private void Call_SetRockchip(bool bValue)
	{
		this.GetJavaObject().Call("SetRockchip", new object[]
		{
			bValue
		});
	}

	// Token: 0x0601AD16 RID: 109846 RVA: 0x0084013F File Offset: 0x0083E53F
	private int Call_GetDuration()
	{
		return this.GetJavaObject().Call<int>("GetDuration", new object[0]);
	}

	// Token: 0x0601AD17 RID: 109847 RVA: 0x00840157 File Offset: 0x0083E557
	private int Call_GetCurrentSeekPercent()
	{
		return this.GetJavaObject().Call<int>("GetCurrentSeekPercent", new object[0]);
	}

	// Token: 0x0601AD18 RID: 109848 RVA: 0x0084016F File Offset: 0x0083E56F
	private int Call_GetError()
	{
		return this.GetJavaObject().Call<int>("GetError", new object[0]);
	}

	// Token: 0x0601AD19 RID: 109849 RVA: 0x00840187 File Offset: 0x0083E587
	private void Call_SetSplitOBB(bool bValue, string strOBBName)
	{
		this.GetJavaObject().Call("SetSplitOBB", new object[]
		{
			bValue,
			strOBBName
		});
	}

	// Token: 0x0601AD1A RID: 109850 RVA: 0x008401AC File Offset: 0x0083E5AC
	private int Call_GetErrorExtra()
	{
		return this.GetJavaObject().Call<int>("GetErrorExtra", new object[0]);
	}

	// Token: 0x0601AD1B RID: 109851 RVA: 0x008401C4 File Offset: 0x0083E5C4
	private void Call_SetUnityActivity()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		this.GetJavaObject().Call("SetUnityActivity", new object[]
		{
			@static
		});
		if (SystemInfo.graphicsMultiThreaded)
		{
			GL.IssuePluginEvent(MediaPlayerCtrl.EasyMovieTextureRender(), this.m_iAndroidMgrID * 10 + 7000);
		}
		else
		{
			this.Call_InitJniManager();
		}
	}

	// Token: 0x0601AD1C RID: 109852 RVA: 0x00840230 File Offset: 0x0083E630
	private void Call_SetNotReady()
	{
		this.GetJavaObject().Call("SetNotReady", new object[0]);
	}

	// Token: 0x0601AD1D RID: 109853 RVA: 0x00840248 File Offset: 0x0083E648
	private void Call_InitJniManager()
	{
		this.GetJavaObject().Call("InitJniManager", new object[0]);
	}

	// Token: 0x0601AD1E RID: 109854 RVA: 0x00840260 File Offset: 0x0083E660
	private void Call_SetSpeed(float fSpeed)
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.os.Build$VERSION"))
		{
			int @static = androidJavaClass.GetStatic<int>("SDK_INT");
			if (@static >= 23)
			{
				this.GetJavaObject().Call("SetSpeed", new object[]
				{
					fSpeed
				});
			}
		}
	}

	// Token: 0x0601AD1F RID: 109855 RVA: 0x008402D0 File Offset: 0x0083E6D0
	private MediaPlayerCtrl.MEDIAPLAYER_STATE Call_GetStatus()
	{
		return (MediaPlayerCtrl.MEDIAPLAYER_STATE)this.GetJavaObject().Call<int>("GetStatus", new object[0]);
	}

	// Token: 0x0601AD20 RID: 109856 RVA: 0x008402E8 File Offset: 0x0083E6E8
	public IEnumerator DownloadStreamingVideoAndLoad(string strURL)
	{
		strURL = strURL.Trim();
		Debug.Log("DownloadStreamingVideo : " + strURL);
		WWW www = new WWW(strURL);
		yield return www;
		if (string.IsNullOrEmpty(www.error))
		{
			if (!Directory.Exists(Application.persistentDataPath + "/Data"))
			{
				Directory.CreateDirectory(Application.persistentDataPath + "/Data");
			}
			string text = Application.persistentDataPath + "/Data" + strURL.Substring(strURL.LastIndexOf("/"));
			File.WriteAllBytes(text, www.bytes);
			this.Load("file://" + text);
		}
		else
		{
			Debug.Log(www.error);
		}
		www.Dispose();
		www = null;
		Resources.UnloadUnusedAssets();
		yield break;
	}

	// Token: 0x0601AD21 RID: 109857 RVA: 0x0084030C File Offset: 0x0083E70C
	public IEnumerator DownloadStreamingVideoAndLoad2(string strURL)
	{
		strURL = strURL.Trim();
		string write_path = Application.persistentDataPath + "/Data" + strURL.Substring(strURL.LastIndexOf("/"));
		if (File.Exists(write_path))
		{
			this.Load("file://" + write_path);
		}
		else
		{
			WWW www = new WWW(strURL);
			yield return www;
			if (string.IsNullOrEmpty(www.error))
			{
				if (!Directory.Exists(Application.persistentDataPath + "/Data"))
				{
					Directory.CreateDirectory(Application.persistentDataPath + "/Data");
				}
				File.WriteAllBytes(write_path, www.bytes);
				this.Load("file://" + write_path);
			}
			else
			{
				Debug.Log(www.error);
			}
			www.Dispose();
			www = null;
			Resources.UnloadUnusedAssets();
		}
		yield break;
	}

	// Token: 0x0601AD22 RID: 109858 RVA: 0x00840330 File Offset: 0x0083E730
	private IEnumerator CopyStreamingAssetVideoAndLoad(string strURL)
	{
		strURL = strURL.Trim();
		string write_path = Application.persistentDataPath + "/" + strURL;
		if (!File.Exists(write_path))
		{
			Debug.Log("CopyStreamingAssetVideoAndLoad : " + strURL);
			WWW www = new WWW(Application.streamingAssetsPath + "/" + strURL);
			yield return www;
			if (string.IsNullOrEmpty(www.error))
			{
				Debug.Log(write_path);
				File.WriteAllBytes(write_path, www.bytes);
				this.Load("file://" + write_path);
			}
			else
			{
				Debug.Log(www.error);
			}
			www.Dispose();
			www = null;
		}
		else
		{
			this.Load("file://" + write_path);
		}
		yield break;
	}

	// Token: 0x0601AD23 RID: 109859 RVA: 0x00840354 File Offset: 0x0083E754
	private void CheckThreading()
	{
		object obj = this.thisLock;
		lock (obj)
		{
			if (this.unityMainThreadActionList.Count > 0)
			{
				foreach (Action action in this.unityMainThreadActionList)
				{
					action();
				}
				this.unityMainThreadActionList.Clear();
			}
		}
	}

	// Token: 0x0601AD24 RID: 109860 RVA: 0x008403F0 File Offset: 0x0083E7F0
	private void AddActionForUnityMainThread(Action a)
	{
		object obj = this.thisLock;
		lock (obj)
		{
			this.unityMainThreadActionList.Add(a);
		}
		this.checkNewActions = true;
	}

	// Token: 0x04012A73 RID: 76403
	public string m_strFileName;

	// Token: 0x04012A74 RID: 76404
	public GameObject[] m_TargetMaterial;

	// Token: 0x04012A75 RID: 76405
	private Texture2D m_VideoTexture;

	// Token: 0x04012A76 RID: 76406
	private Texture2D m_VideoTextureDummy;

	// Token: 0x04012A77 RID: 76407
	private MediaPlayerCtrl.MEDIAPLAYER_STATE m_CurrentState;

	// Token: 0x04012A78 RID: 76408
	private int m_iCurrentSeekPosition;

	// Token: 0x04012A79 RID: 76409
	private float m_fVolume = 1f;

	// Token: 0x04012A7A RID: 76410
	private int m_iWidth;

	// Token: 0x04012A7B RID: 76411
	private int m_iHeight;

	// Token: 0x04012A7C RID: 76412
	private float m_fSpeed = 1f;

	// Token: 0x04012A7D RID: 76413
	public bool m_bFullScreen;

	// Token: 0x04012A7E RID: 76414
	public bool m_bSupportRockchip = true;

	// Token: 0x04012A7F RID: 76415
	public MediaPlayerCtrl.VideoResize OnResize;

	// Token: 0x04012A80 RID: 76416
	public MediaPlayerCtrl.VideoReady OnReady;

	// Token: 0x04012A81 RID: 76417
	public MediaPlayerCtrl.VideoEnd OnEnd;

	// Token: 0x04012A82 RID: 76418
	public MediaPlayerCtrl.VideoError OnVideoError;

	// Token: 0x04012A83 RID: 76419
	public MediaPlayerCtrl.VideoFirstFrameReady OnVideoFirstFrameReady;

	// Token: 0x04012A84 RID: 76420
	private IntPtr m_texPtr;

	// Token: 0x04012A85 RID: 76421
	private int m_iAndroidMgrID;

	// Token: 0x04012A86 RID: 76422
	private bool m_bIsFirstFrameReady;

	// Token: 0x04012A87 RID: 76423
	private bool m_bFirst;

	// Token: 0x04012A88 RID: 76424
	public MediaPlayerCtrl.MEDIA_SCALE m_ScaleValue;

	// Token: 0x04012A89 RID: 76425
	public GameObject[] m_objResize;

	// Token: 0x04012A8A RID: 76426
	public bool m_bLoop;

	// Token: 0x04012A8B RID: 76427
	public bool m_bAutoPlay = true;

	// Token: 0x04012A8C RID: 76428
	private bool m_bStop;

	// Token: 0x04012A8D RID: 76429
	private bool m_bInit;

	// Token: 0x04012A8E RID: 76430
	private bool m_bCheckFBO;

	// Token: 0x04012A8F RID: 76431
	private bool m_bPause;

	// Token: 0x04012A90 RID: 76432
	private bool m_bReadyPlay;

	// Token: 0x04012A91 RID: 76433
	private AndroidJavaObject javaObj;

	// Token: 0x04012A92 RID: 76434
	private List<Action> unityMainThreadActionList = new List<Action>();

	// Token: 0x04012A93 RID: 76435
	private bool checkNewActions;

	// Token: 0x04012A94 RID: 76436
	private object thisLock = new object();

	// Token: 0x020048CB RID: 18635
	// (Invoke) Token: 0x0601AD26 RID: 109862
	public delegate void VideoEnd();

	// Token: 0x020048CC RID: 18636
	// (Invoke) Token: 0x0601AD2A RID: 109866
	public delegate void VideoReady();

	// Token: 0x020048CD RID: 18637
	// (Invoke) Token: 0x0601AD2E RID: 109870
	public delegate void VideoError(MediaPlayerCtrl.MEDIAPLAYER_ERROR errorCode, MediaPlayerCtrl.MEDIAPLAYER_ERROR errorCodeExtra);

	// Token: 0x020048CE RID: 18638
	// (Invoke) Token: 0x0601AD32 RID: 109874
	public delegate void VideoFirstFrameReady();

	// Token: 0x020048CF RID: 18639
	// (Invoke) Token: 0x0601AD36 RID: 109878
	public delegate void VideoResize();

	// Token: 0x020048D0 RID: 18640
	public enum MEDIAPLAYER_ERROR
	{
		// Token: 0x04012A96 RID: 76438
		MEDIA_ERROR_NOT_VALID_FOR_PROGRESSIVE_PLAYBACK = 200,
		// Token: 0x04012A97 RID: 76439
		MEDIA_ERROR_IO = -1004,
		// Token: 0x04012A98 RID: 76440
		MEDIA_ERROR_MALFORMED = -1007,
		// Token: 0x04012A99 RID: 76441
		MEDIA_ERROR_TIMED_OUT = -110,
		// Token: 0x04012A9A RID: 76442
		MEDIA_ERROR_UNSUPPORTED = -1010,
		// Token: 0x04012A9B RID: 76443
		MEDIA_ERROR_SERVER_DIED = 100,
		// Token: 0x04012A9C RID: 76444
		MEDIA_ERROR_UNKNOWN = 1
	}

	// Token: 0x020048D1 RID: 18641
	public enum MEDIAPLAYER_STATE
	{
		// Token: 0x04012A9E RID: 76446
		NOT_READY,
		// Token: 0x04012A9F RID: 76447
		READY,
		// Token: 0x04012AA0 RID: 76448
		END,
		// Token: 0x04012AA1 RID: 76449
		PLAYING,
		// Token: 0x04012AA2 RID: 76450
		PAUSED,
		// Token: 0x04012AA3 RID: 76451
		STOPPED,
		// Token: 0x04012AA4 RID: 76452
		ERROR
	}

	// Token: 0x020048D2 RID: 18642
	public enum MEDIA_SCALE
	{
		// Token: 0x04012AA6 RID: 76454
		SCALE_X_TO_Y,
		// Token: 0x04012AA7 RID: 76455
		SCALE_X_TO_Z,
		// Token: 0x04012AA8 RID: 76456
		SCALE_Y_TO_X,
		// Token: 0x04012AA9 RID: 76457
		SCALE_Y_TO_Z,
		// Token: 0x04012AAA RID: 76458
		SCALE_Z_TO_X,
		// Token: 0x04012AAB RID: 76459
		SCALE_Z_TO_Y,
		// Token: 0x04012AAC RID: 76460
		SCALE_X_TO_Y_2
	}
}
