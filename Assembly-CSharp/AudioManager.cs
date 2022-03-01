using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameClient;
using ProtoTable;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class AudioManager : MonoSingleton<AudioManager>
{
	// Token: 0x0600050C RID: 1292 RVA: 0x00022008 File Offset: 0x00020408
	public AudioManager()
	{
		if (AudioManager.<>f__mg$cache0 == null)
		{
			AudioManager.<>f__mg$cache0 = new OnAssetLoadSuccess(AudioManager._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = AudioManager.<>f__mg$cache0;
		if (AudioManager.<>f__mg$cache1 == null)
		{
			AudioManager.<>f__mg$cache1 = new OnAssetLoadFailure(AudioManager._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, AudioManager.<>f__mg$cache1);
		base..ctor();
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x000220B0 File Offset: 0x000204B0
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		if (userData == null)
		{
			TMDebug.LogErrorFormat("User data can not be null!", new object[0]);
			return;
		}
		AudioManager audioManager = userData as AudioManager;
		if (null == audioManager)
		{
			TMDebug.LogErrorFormat("User data type '{0}' is NOT AudioManager!", new object[0]);
			return;
		}
		AudioClip audioClip = asset as AudioClip;
		if (null == audioClip)
		{
			TMDebug.LogErrorFormat("Asset type '{0}' error!", new object[]
			{
				asset.GetType()
			});
			return;
		}
		int i = 0;
		int count = audioManager.m_AsyncPlayCommandList.Count;
		while (i < count)
		{
			AudioManager.AsyncPlayCommand asyncPlayCommand = audioManager.m_AsyncPlayCommandList[i];
			if (asyncPlayCommand != null && grpID == (int)asyncPlayCommand.m_AsyncLoad)
			{
				if (null != audioClip)
				{
					asyncPlayCommand.m_AudioInst.volume = audioManager.m_AudioVolume[(int)((UIntPtr)asyncPlayCommand.m_AudioType)];
					asyncPlayCommand.m_AudioInst.orginVolume = asyncPlayCommand.m_Volume;
					asyncPlayCommand.m_AudioInst.Play(asyncPlayCommand.m_AudioName, asyncPlayCommand.m_AudioHandle, audioClip, asyncPlayCommand.m_IsLoop, asyncPlayCommand.m_AttachObj, asyncPlayCommand.endCallback);
					asyncPlayCommand.m_AudioInst.isMute = audioManager.m_AudioMute[(int)((UIntPtr)asyncPlayCommand.m_AudioType)];
				}
				asyncPlayCommand.m_AsyncLoad = AssetLoader.INVILID_HANDLE;
				asyncPlayCommand.m_AttachObj = null;
				asyncPlayCommand.m_AudioInst = null;
				asyncPlayCommand.m_AudioName = null;
				asyncPlayCommand.m_AudioType = 4U;
				asyncPlayCommand.m_IsLoop = false;
				asyncPlayCommand.m_Volume = 1f;
				audioManager.m_AsyncIdleCommandList.Add(asyncPlayCommand);
				audioManager.m_AsyncPlayCommandList.RemoveAt(i);
				break;
			}
			i++;
		}
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x0002224A File Offset: 0x0002064A
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
		Logger.LogErrorFormat("[AudioManager]Load asset '{0}' has failed![Error:{1}]", new object[]
		{
			assetPath,
			errorMessage
		});
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x00022264 File Offset: 0x00020664
	public override void Init()
	{
		this.Clear();
		this._Reinit();
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00022274 File Offset: 0x00020674
	private void Update()
	{
		this.m_FrameCnt += 1U;
		this._UpdateAsync();
		if (this.m_FrameCnt < 5U)
		{
			return;
		}
		bool flag = Singleton<SDKVoiceManager>.instance.IsVoicePlaying();
		if (flag != this.m_bPreStateVoicePlaying)
		{
			this.m_bPreStateVoicePlaying = flag;
			float num = (!flag) ? 1f : 0.3f;
			float volume = num * (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume;
			this.SetVolume(AudioType.AudioStream, volume);
			float volume2 = num * (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Volume;
			this.SetVolume(AudioType.AudioEffect, volume2);
			this.SetVolume(AudioType.AudioVoice, volume2);
			this.SetVolume(AudioType.AudioGuide, volume2);
		}
		for (int i = 0; i < this.m_AudioDescList.Length; i++)
		{
			List<AudioManager.AudioInst> list = this.m_AudioDescList[i];
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					AudioManager.AudioInst audioInst = list[j];
					if (audioInst.IsEnd())
					{
						audioInst.Update(165);
						audioInst.OnEnd();
						audioInst.Stop();
					}
				}
			}
		}
		this.m_FrameCnt = 0U;
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x000223B0 File Offset: 0x000207B0
	protected AudioManager.AsyncPlayCommand _AllocateAsyncCommand()
	{
		if (this.m_AsyncIdleCommandList.Count > 0)
		{
			int index = this.m_AsyncIdleCommandList.Count - 1;
			AudioManager.AsyncPlayCommand result = this.m_AsyncIdleCommandList[index];
			this.m_AsyncIdleCommandList.RemoveAt(index);
			return result;
		}
		return new AudioManager.AsyncPlayCommand();
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00022400 File Offset: 0x00020800
	protected void _UpdateAsync()
	{
		int i = 0;
		int count = this.m_AsyncPlayCommandList.Count;
		while (i < count)
		{
			AudioManager.AsyncPlayCommand asyncPlayCommand = this.m_AsyncPlayCommandList[i];
			if (asyncPlayCommand != null && AssetLoader.INVILID_HANDLE != asyncPlayCommand.m_AsyncLoad)
			{
				if (!Singleton<AssetLoader>.instance.IsRequestDone(asyncPlayCommand.m_AsyncLoad))
				{
					i++;
					continue;
				}
				AudioClip audioClip = Singleton<AssetLoader>.instance.Extract(asyncPlayCommand.m_AsyncLoad).obj as AudioClip;
				if (null != audioClip)
				{
					asyncPlayCommand.m_AudioInst.volume = this.m_AudioVolume[(int)((UIntPtr)asyncPlayCommand.m_AudioType)];
					asyncPlayCommand.m_AudioInst.orginVolume = asyncPlayCommand.m_Volume;
					asyncPlayCommand.m_AudioInst.SetPitch(asyncPlayCommand.speed);
					asyncPlayCommand.m_AudioInst.Play(asyncPlayCommand.m_AudioName, asyncPlayCommand.m_AudioHandle, audioClip, asyncPlayCommand.m_IsLoop, asyncPlayCommand.m_AttachObj, asyncPlayCommand.endCallback);
					asyncPlayCommand.m_AudioInst.isMute = this.m_AudioMute[(int)((UIntPtr)asyncPlayCommand.m_AudioType)];
				}
				asyncPlayCommand.m_AsyncLoad = AssetLoader.INVILID_HANDLE;
			}
			if (asyncPlayCommand != null)
			{
				asyncPlayCommand.m_AsyncLoad = AssetLoader.INVILID_HANDLE;
				asyncPlayCommand.m_AttachObj = null;
				asyncPlayCommand.m_AudioInst = null;
				asyncPlayCommand.m_AudioName = null;
				asyncPlayCommand.m_AudioType = 4U;
				asyncPlayCommand.m_IsLoop = false;
				asyncPlayCommand.m_Volume = 1f;
				this.m_AsyncIdleCommandList.Add(asyncPlayCommand);
			}
			this.m_AsyncPlayCommandList.RemoveAt(i);
			break;
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00022579 File Offset: 0x00020979
	protected override void OnDestroy()
	{
		this.Clear();
		base.OnDestroy();
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00022588 File Offset: 0x00020988
	public void Clear()
	{
		for (int i = 0; i < this.m_AudioDescList.Length; i++)
		{
			List<AudioManager.AudioInst> list = this.m_AudioDescList[i];
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					list[j].Deinit();
				}
				list.Clear();
			}
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x000225EC File Offset: 0x000209EC
	public void PreloadSound(string audioRes)
	{
		if (this.IsMute(AudioType.AudioEffect))
		{
			return;
		}
		MonoSingleton<CResPreloader>.instance.AddRes(audioRes, false, 1, null, 0, null, CResPreloader.ResType.RES, typeof(AudioClip));
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00022624 File Offset: 0x00020A24
	public void PreloadSound(int soundID)
	{
		if (soundID <= 0)
		{
			return;
		}
		SoundTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(soundID, string.Empty, string.Empty);
		if (tableItem == null || (tableItem != null && tableItem.Path.Count <= 0))
		{
			return;
		}
		for (int i = 0; i < tableItem.Path.Count; i++)
		{
			string audioRes = tableItem.Path[i];
			this.PreloadSound(audioRes);
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x0002269D File Offset: 0x00020A9D
	public void AddPreloadSound(Object clip)
	{
		if (clip == null)
		{
			return;
		}
		this.preloadedClips.Add(clip);
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x000226B8 File Offset: 0x00020AB8
	public void ClearPreloadSound()
	{
		this.preloadedClips.Clear();
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x000226C8 File Offset: 0x00020AC8
	public uint PlaySound(AudioClip audioClip, AudioType type, float volume = 1f, bool isLoop = false, GameObject attachObj = null, bool isExculsive = false, bool AsyncLoad = false, OnAudioEndCallback callback = null, float speed = 1f)
	{
		if (null != audioClip)
		{
			if (type < AudioType.MaxTypeNum)
			{
				if (type != AudioType.AudioStream && this.IsMute(type))
				{
					if (callback != null)
					{
						callback();
					}
					return uint.MaxValue;
				}
				string name = audioClip.name;
				uint num;
				if (isExculsive)
				{
					num = this._CheckExclusive(name, type);
					if (num != 4294967295U)
					{
						if (callback != null)
						{
							callback();
						}
						return num;
					}
				}
				num = (this._AllocHandle() | (uint)((uint)(type % AudioType.AudioGuide) << 30));
				AudioManager.AudioInst audioInst = this._GetAvailableAudioInst(type);
				if (audioInst != null)
				{
					audioInst.orginVolume = volume;
					audioInst.volume = this.m_AudioVolume[(int)type];
					audioInst.Play(name, num, audioClip, isLoop, attachObj, callback);
					audioInst.isMute = this.m_AudioMute[(int)((UIntPtr)type)];
					audioInst.SetPitch(speed);
					return num;
				}
			}
		}
		if (callback != null)
		{
			callback();
		}
		return uint.MaxValue;
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x000227B0 File Offset: 0x00020BB0
	public uint PlaySound(string audioRes, AudioType type, float volume = 1f, bool isLoop = false, GameObject attachObj = null, bool isExculsive = false, bool AsyncLoad = false, OnAudioEndCallback callback = null, float speed = 1f)
	{
		AsyncLoad = false;
		if (!string.IsNullOrEmpty(audioRes) && global::Utility.IsStringValid(audioRes))
		{
			if (type < AudioType.MaxTypeNum)
			{
				if (type != AudioType.AudioStream && this.IsMute(type))
				{
					if (callback != null)
					{
						callback();
					}
					return uint.MaxValue;
				}
				if (isExculsive)
				{
					uint num = this._CheckExclusive(audioRes, type);
					if (num != 4294967295U)
					{
						if (callback != null)
						{
							callback();
						}
						return num;
					}
				}
				AudioManager.AudioInst audioInst = this._GetAvailableAudioInst(type);
				if (audioInst != null)
				{
					uint num = this._AllocHandle() | (uint)((uint)(type % AudioType.AudioGuide) << 30);
					if (AsyncLoad)
					{
						AudioManager.AsyncPlayCommand asyncPlayCommand = this._AllocateAsyncCommand();
						if (asyncPlayCommand != null)
						{
							asyncPlayCommand.m_AsyncLoad = Singleton<AssetLoader>.instance.LoadResAync(audioRes, typeof(AudioClip), true, 0U, 0U);
							asyncPlayCommand.m_AttachObj = attachObj;
							asyncPlayCommand.m_AudioHandle = num;
							asyncPlayCommand.m_AudioInst = audioInst;
							asyncPlayCommand.m_AudioName = audioRes;
							asyncPlayCommand.m_AudioType = (uint)type;
							asyncPlayCommand.m_IsLoop = isLoop;
							asyncPlayCommand.m_Volume = volume;
							asyncPlayCommand.endCallback = callback;
							asyncPlayCommand.speed = speed;
							this.m_AsyncPlayCommandList.Add(asyncPlayCommand);
							return num;
						}
					}
					else
					{
						AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(audioRes, typeof(AudioClip), true, 0U);
						if (assetInst != null && assetInst.obj != null)
						{
							AudioClip audioClip = assetInst.obj as AudioClip;
							if (null != audioClip)
							{
								audioInst.volume = this.m_AudioVolume[(int)((UIntPtr)type)];
								audioInst.orginVolume = volume;
								audioInst.Play(audioRes, num, audioClip, isLoop, attachObj, callback);
								audioInst.isMute = this.m_AudioMute[(int)((UIntPtr)type)];
								audioInst.SetPitch(speed);
								return num;
							}
						}
					}
				}
			}
		}
		if (callback != null)
		{
			callback();
		}
		return uint.MaxValue;
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00022988 File Offset: 0x00020D88
	public uint PlaySound(int soundID)
	{
		if (soundID == 0)
		{
			return uint.MaxValue;
		}
		SoundTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(soundID, string.Empty, string.Empty);
		if (tableItem == null || (tableItem != null && tableItem.Path.Count <= 0))
		{
			return uint.MaxValue;
		}
		string audioRes = tableItem.Path[0];
		if (tableItem.IsRandom > 0 && tableItem.Path.Count > 1)
		{
			audioRes = tableItem.Path[Random.Range(0, tableItem.Path.Count)];
		}
		bool isLoop = tableItem.Loop > 0;
		return this.PlaySound(audioRes, AudioType.AudioEffect, 1f, isLoop, null, true, false, null, 1f);
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00022A3C File Offset: 0x00020E3C
	public uint PlaySound(SoundTable data, float speed = 1f, float volume = 1f)
	{
		if (data == null || (data != null && data.Path.Count <= 0))
		{
			return uint.MaxValue;
		}
		string audioRes = data.Path[0];
		if (data.IsRandom > 0 && data.Path.Count > 1)
		{
			audioRes = data.Path[Random.Range(0, data.Path.Count)];
		}
		return this.PlaySound(audioRes, AudioType.AudioEffect, volume, false, null, true, false, null, speed);
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00022AC0 File Offset: 0x00020EC0
	public uint PlayGuideAudio(string audioRes, float volume = 1f, OnAudioEndCallback callback = null, bool isLoop = false, GameObject attachObj = null, bool isExculsive = false)
	{
		this.SetVolume(AudioType.AudioEffect, 0f);
		return this.PlaySound(audioRes, AudioType.AudioGuide, volume, isLoop, attachObj, isExculsive, false, delegate()
		{
			this.SetVolume(AudioType.AudioEffect, (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Volume);
			if (callback != null)
			{
				callback();
			}
		}, 1f);
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00022B10 File Offset: 0x00020F10
	protected void _Reinit()
	{
		for (int i = 0; i < 4; i++)
		{
			this.m_AudioDescList[i] = new List<AudioManager.AudioInst>();
		}
		this.m_AudioVolume[1] = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume;
		this.m_AudioVolume[0] = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Volume;
		this.m_AudioVolume[2] = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Volume;
		this.m_AudioVolume[3] = 1f;
		this.m_AudioMute[1] = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Mute;
		this.m_AudioMute[0] = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Mute;
		this.m_AudioMute[2] = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig.Mute;
		this.m_AudioMute[3] = false;
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00022C00 File Offset: 0x00021000
	protected uint _CheckExclusive(string audioName, AudioType type)
	{
		if (type < AudioType.MaxTypeNum)
		{
			List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)type)];
			if (list == null)
			{
				return uint.MaxValue;
			}
			for (int i = 0; i < list.Count; i++)
			{
				AudioManager.AudioInst audioInst = list[i];
				if (audioInst.IsEnd())
				{
					if (audioInst.audioClipName == audioName)
					{
						return audioInst.handle;
					}
				}
			}
		}
		return uint.MaxValue;
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00022C70 File Offset: 0x00021070
	protected AudioManager.AudioInst _GetAvailableAudioInst(AudioType type)
	{
		if (type >= AudioType.MaxTypeNum)
		{
			return null;
		}
		uint num = this._AllocHandle() | (uint)((uint)(type % AudioType.AudioGuide) << 30);
		List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)type)];
		if (list == null)
		{
			return null;
		}
		AudioManager.AudioInst audioInst = null;
		for (int i = 0; i < list.Count; i++)
		{
			AudioManager.AudioInst audioInst2 = list[i];
			if (audioInst2.IsEnd())
			{
				audioInst = audioInst2;
				break;
			}
		}
		if (audioInst == null && list.Count < AudioManager.MAX_AUDIOSOURCE_NUM)
		{
			AudioManager.AudioInst audioInst3 = new AudioManager.AudioInst();
			if (audioInst3.Init())
			{
				audioInst = audioInst3;
				list.Add(audioInst3);
			}
		}
		return audioInst;
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x00022D18 File Offset: 0x00021118
	public IAudioInst GetAudioInst(uint hHandle)
	{
		uint num = (hHandle >> 30) % 3U;
		List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)num)];
		if (list == null)
		{
			return null;
		}
		for (int i = 0; i < list.Count; i++)
		{
			AudioManager.AudioInst audioInst = list[i];
			if (hHandle == audioInst.handle)
			{
				return audioInst;
			}
		}
		return null;
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x00022D6C File Offset: 0x0002116C
	public bool IsMute(AudioType type)
	{
		return this.m_AudioMute[(int)((UIntPtr)type)];
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00022D84 File Offset: 0x00021184
	public void SetMute(AudioType type, bool isMute)
	{
		if (type < AudioType.MaxTypeNum)
		{
			this.m_AudioMute[(int)((UIntPtr)type)] = isMute;
			List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)type)];
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].isMute = isMute;
			}
		}
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x00022DDC File Offset: 0x000211DC
	public void SetVolume(AudioType type, float volume)
	{
		if (type < AudioType.MaxTypeNum)
		{
			List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)type)];
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				AudioManager.AudioInst audioInst = list[i];
				audioInst.volume = volume;
			}
			this.m_AudioVolume[(int)((UIntPtr)type)] = volume;
		}
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x00022E34 File Offset: 0x00021234
	public float GetVolume(AudioType type)
	{
		if (type < AudioType.MaxTypeNum)
		{
			List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)type)];
			if (list != null && list.Count > 0)
			{
				AudioManager.AudioInst audioInst = list[0];
				return audioInst.volume;
			}
		}
		return 1f;
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x00022E7C File Offset: 0x0002127C
	public void Stop(uint handle)
	{
		if (handle == 4294967295U)
		{
			return;
		}
		IAudioInst audioInst = this.GetAudioInst(handle);
		if (audioInst != null)
		{
			audioInst.Stop();
		}
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x00022EA8 File Offset: 0x000212A8
	public void StopAll(AudioType type)
	{
		if (type < AudioType.MaxTypeNum)
		{
			List<AudioManager.AudioInst> list = this.m_AudioDescList[(int)((UIntPtr)type)];
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Stop();
			}
		}
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x00022EF4 File Offset: 0x000212F4
	public int GetAudioLength(uint handle)
	{
		IAudioInst audioInst = this.GetAudioInst(handle);
		if (audioInst != null)
		{
			return audioInst.GetLength();
		}
		return 0;
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00022F18 File Offset: 0x00021318
	protected uint _AllocHandle()
	{
		if (this.m_CurAudioHandleCnt + 1U == 1073741823U)
		{
			this.m_CurAudioHandleCnt = 0U;
		}
		return this.m_CurAudioHandleCnt++;
	}

	// Token: 0x0400048B RID: 1163
	protected static int MAX_AUDIOSOURCE_NUM = 8;

	// Token: 0x0400048C RID: 1164
	protected float[] m_AudioVolume = new float[4];

	// Token: 0x0400048D RID: 1165
	protected bool[] m_AudioMute = new bool[4];

	// Token: 0x0400048E RID: 1166
	protected List<AudioManager.AudioInst>[] m_AudioDescList = new List<AudioManager.AudioInst>[4];

	// Token: 0x0400048F RID: 1167
	protected uint m_CurAudioHandleCnt;

	// Token: 0x04000490 RID: 1168
	protected uint m_FrameCnt;

	// Token: 0x04000491 RID: 1169
	protected List<AudioManager.AsyncPlayCommand> m_AsyncPlayCommandList = new List<AudioManager.AsyncPlayCommand>();

	// Token: 0x04000492 RID: 1170
	protected List<AudioManager.AsyncPlayCommand> m_AsyncIdleCommandList = new List<AudioManager.AsyncPlayCommand>();

	// Token: 0x04000493 RID: 1171
	protected List<Object> preloadedClips = new List<Object>();

	// Token: 0x04000494 RID: 1172
	private bool m_UseTMEngine = true;

	// Token: 0x04000495 RID: 1173
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x04000496 RID: 1174
	private bool m_bPreStateVoicePlaying;

	// Token: 0x04000497 RID: 1175
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x04000498 RID: 1176
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;

	// Token: 0x020000F6 RID: 246
	protected class AudioInst : IAudioInst
	{
		// Token: 0x0600052B RID: 1323 RVA: 0x00022F58 File Offset: 0x00021358
		public AudioInst()
		{
			this.m_AudioClip = null;
			this.m_AudioSource = null;
			this.m_AttachParent = null;
			this.m_AudioSrcObj = null;
			this.m_IsLoop = false;
			this.m_IsMute = false;
			this.m_AudioName = null;
			this.m_OrginVolume = 1f;
			this.m_Volume = 1f;
			this.m_Handle = uint.MaxValue;
			this.m_PlayFrame = false;
			this.m_Callback = null;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00022FE4 File Offset: 0x000213E4
		public bool Init()
		{
			this.m_AudioSrcObj = new GameObject("AudioSource");
			if (null != this.m_AudioSrcObj)
			{
				this.m_AudioSource = this.m_AudioSrcObj.AddComponent<AudioSource>();
				if (null != this.m_AudioSource)
				{
					return true;
				}
				Logger.LogError("Add audio source has failed!");
			}
			else
			{
				Logger.LogError("Create audio source game object has failed!");
			}
			return false;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00023050 File Offset: 0x00021450
		public void Deinit()
		{
			this.Stop();
			if (null != this.m_AudioSrcObj)
			{
				if (null != this.m_AudioSource)
				{
					this.m_AudioSource = null;
				}
				Object.Destroy(this.m_AudioSrcObj);
				this.m_AudioSrcObj = null;
			}
			this.m_AttachParent = null;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000230A8 File Offset: 0x000214A8
		public void Play(string clipName, uint handle, AudioClip audioClip, bool isLoop, GameObject attachObj, OnAudioEndCallback endCallback)
		{
			if (null == this.m_AudioSrcObj)
			{
				Logger.LogError("Invalid audio source instance!");
				return;
			}
			if (null != attachObj)
			{
				this.m_AttachParent = attachObj;
				this.m_AudioSrcObj.transform.SetParent(this.m_AttachParent.transform, false);
			}
			this.m_Handle = handle;
			this.m_AudioClip = audioClip;
			this.m_AudioName = clipName;
			this.m_IsLoop = isLoop;
			this.m_AudioSource.loop = this.m_IsLoop;
			this.m_AudioSource.clip = audioClip;
			this.m_AudioSource.Play();
			this.m_Callback = endCallback;
			this.m_PlayFrame = true;
			this.m_PlayTime = 0;
			this.m_TimeLength = (int)(this.m_AudioClip.length * 1000f);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00023175 File Offset: 0x00021575
		public void Pause()
		{
			this.m_AudioSource.Pause();
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00023182 File Offset: 0x00021582
		public void Resume()
		{
			this.m_AudioSource.UnPause();
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0002318F File Offset: 0x0002158F
		public int GetLength()
		{
			return this.m_TimeLength;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00023197 File Offset: 0x00021597
		public void Update(int ElpasedTIme)
		{
			if (ElpasedTIme > 0)
			{
				this.m_PlayTime += ElpasedTIme;
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x000231AE File Offset: 0x000215AE
		public void OnEnd()
		{
			if (this.m_PlayTime > this.m_TimeLength && this.m_Callback != null)
			{
				this.m_Callback();
				this.m_Callback = null;
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x000231E0 File Offset: 0x000215E0
		public void Stop()
		{
			if (null == this.m_AudioClip)
			{
				return;
			}
			if (null != this.m_AudioSource)
			{
				this.m_AudioSource.Stop();
				this.m_AudioSource.clip = null;
				this.m_AudioSource.loop = false;
			}
			if (null != this.m_AudioClip)
			{
				this.m_AudioClip = null;
			}
			this.m_AttachParent = null;
			this.m_Handle = uint.MaxValue;
			this.m_AudioName = string.Empty;
			this.m_IsLoop = false;
			if (this.m_Callback != null)
			{
				this.m_Callback();
				this.m_Callback = null;
			}
			this.m_TimeLength = 0;
			this.m_PlayTime = 0;
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00023298 File Offset: 0x00021698
		public bool IsEnd()
		{
			if (this.m_PlayFrame)
			{
				this.m_PlayFrame = false;
				return false;
			}
			return this.m_AudioSource == null || (!this.m_AudioSource.isPlaying && false == this.m_AudioSource.loop);
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x000232ED File Offset: 0x000216ED
		public bool isLoop
		{
			get
			{
				return this.m_IsLoop;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x000232F5 File Offset: 0x000216F5
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x000232FD File Offset: 0x000216FD
		public bool isMute
		{
			get
			{
				return this.m_IsMute;
			}
			set
			{
				this.m_IsMute = value;
				if (null != this.m_AudioSource)
				{
					this.m_AudioSource.mute = this.m_IsMute;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x00023328 File Offset: 0x00021728
		// (set) Token: 0x0600053A RID: 1338 RVA: 0x00023330 File Offset: 0x00021730
		public float volume
		{
			get
			{
				return this.m_Volume;
			}
			set
			{
				this.m_Volume = value;
				if (null != this.m_AudioSource)
				{
					this.m_AudioSource.volume = this.m_Volume * this.m_OrginVolume;
				}
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00023362 File Offset: 0x00021762
		public void SetPitch(float pitch)
		{
			this.pitch = pitch;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0002336B File Offset: 0x0002176B
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x0002338F File Offset: 0x0002178F
		public float pitch
		{
			get
			{
				if (this.m_AudioSource != null)
				{
					return this.m_AudioSource.pitch;
				}
				return 0f;
			}
			set
			{
				if (this.m_AudioSource != null)
				{
					this.m_AudioSource.pitch = value;
				}
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x000233AE File Offset: 0x000217AE
		public string audioClipName
		{
			get
			{
				return this.m_AudioName;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x000233B6 File Offset: 0x000217B6
		public uint handle
		{
			get
			{
				return this.m_Handle;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x000233BE File Offset: 0x000217BE
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x000233C6 File Offset: 0x000217C6
		public float orginVolume
		{
			get
			{
				return this.m_OrginVolume;
			}
			set
			{
				this.m_OrginVolume = value;
				if (null != this.m_AudioSource)
				{
					this.m_AudioSource.volume = this.m_Volume * this.m_OrginVolume;
				}
			}
		}

		// Token: 0x04000499 RID: 1177
		protected AudioClip m_AudioClip;

		// Token: 0x0400049A RID: 1178
		protected AudioSource m_AudioSource;

		// Token: 0x0400049B RID: 1179
		protected GameObject m_AttachParent;

		// Token: 0x0400049C RID: 1180
		protected GameObject m_AudioSrcObj;

		// Token: 0x0400049D RID: 1181
		protected bool m_IsLoop;

		// Token: 0x0400049E RID: 1182
		protected bool m_IsMute;

		// Token: 0x0400049F RID: 1183
		protected string m_AudioName;

		// Token: 0x040004A0 RID: 1184
		protected float m_OrginVolume = 1f;

		// Token: 0x040004A1 RID: 1185
		protected float m_Volume = 1f;

		// Token: 0x040004A2 RID: 1186
		protected uint m_Handle = uint.MaxValue;

		// Token: 0x040004A3 RID: 1187
		protected bool m_PlayFrame;

		// Token: 0x040004A4 RID: 1188
		protected OnAudioEndCallback m_Callback;

		// Token: 0x040004A5 RID: 1189
		protected int m_PlayTime;

		// Token: 0x040004A6 RID: 1190
		protected int m_TimeLength;
	}

	// Token: 0x020000F7 RID: 247
	protected class AsyncPlayCommand
	{
		// Token: 0x040004A7 RID: 1191
		public uint m_AsyncLoad = AssetLoader.INVILID_HANDLE;

		// Token: 0x040004A8 RID: 1192
		public float m_Volume = 1f;

		// Token: 0x040004A9 RID: 1193
		public bool m_IsLoop;

		// Token: 0x040004AA RID: 1194
		public GameObject m_AttachObj;

		// Token: 0x040004AB RID: 1195
		public uint m_AudioType;

		// Token: 0x040004AC RID: 1196
		public AudioManager.AudioInst m_AudioInst;

		// Token: 0x040004AD RID: 1197
		public uint m_AudioHandle = uint.MaxValue;

		// Token: 0x040004AE RID: 1198
		public string m_AudioName;

		// Token: 0x040004AF RID: 1199
		public OnAudioEndCallback endCallback;

		// Token: 0x040004B0 RID: 1200
		public float speed;
	}
}
