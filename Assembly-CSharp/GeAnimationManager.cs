using System;
using UnityEngine;

// Token: 0x02000CD7 RID: 3287
public class GeAnimationManager
{
	// Token: 0x060086DA RID: 34522 RVA: 0x0017AAAC File Offset: 0x00178EAC
	public bool Init(GameObject actor)
	{
		if (null != actor)
		{
			this.m_AnimDescProxy = actor.GetComponentInChildren<GeAnimDescProxy>();
			if (null != this.m_AnimDescProxy)
			{
				if (null == this.m_AnimDescProxy.animInstance)
				{
					this.m_AnimDescProxy.animInstance = this.m_AnimDescProxy.gameObject.GetComponent<Animation>();
				}
				if (null == this.m_AnimDescProxy.animInstance)
				{
					this.m_AnimDescProxy.animInstance = actor.GetComponentInChildren<Animation>();
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060086DB RID: 34523 RVA: 0x0017AB40 File Offset: 0x00178F40
	public void Deinit()
	{
		if (null != this.m_AnimDescProxy && null != this.m_AnimDescProxy.animInstance)
		{
			this.m_AnimDescProxy.animInstance.Stop();
			if (this.m_AnimDescProxy.animDescArray != null)
			{
				int i = 0;
				int num = this.m_AnimDescProxy.animDescArray.Length;
				while (i < num)
				{
					GeAnimDesc geAnimDesc = this.m_AnimDescProxy.animDescArray[i];
					if (geAnimDesc != null && !(null == geAnimDesc.animClipData))
					{
						AnimationClip clip = this.m_AnimDescProxy.animInstance.GetClip(geAnimDesc.animClipName);
						if (null != clip)
						{
							this.m_AnimDescProxy.animInstance.RemoveClip(clip);
						}
						geAnimDesc.animClipData = null;
					}
					i++;
				}
			}
			this.m_AnimDescProxy = null;
		}
	}

	// Token: 0x060086DC RID: 34524 RVA: 0x0017AC20 File Offset: 0x00179020
	public bool HasAnimClipDesc(string clipName)
	{
		if (null != this.m_AnimDescProxy && this.m_AnimDescProxy.animDescArray != null)
		{
			for (int i = 0; i < this.m_AnimDescProxy.animDescArray.Length; i++)
			{
				if (this.m_AnimDescProxy.animDescArray[i].animClipName.Equals(clipName))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060086DD RID: 34525 RVA: 0x0017AC8C File Offset: 0x0017908C
	public GeAnimDesc GetAnimClipDesc(string clipName)
	{
		if (null != this.m_AnimDescProxy && this.m_AnimDescProxy.animDescArray != null)
		{
			for (int i = 0; i < this.m_AnimDescProxy.animDescArray.Length; i++)
			{
				if (this.m_AnimDescProxy.animDescArray[i].animClipName.CompareTo(clipName) == 0)
				{
					return this.m_AnimDescProxy.animDescArray[i];
				}
			}
		}
		return GeAnimationManager.sInvalidAnimDesc;
	}

	// Token: 0x060086DE RID: 34526 RVA: 0x0017AD08 File Offset: 0x00179108
	public float GetCurrentAnimationSpeed()
	{
		return this.m_CurSpeed;
	}

	// Token: 0x060086DF RID: 34527 RVA: 0x0017AD10 File Offset: 0x00179110
	public bool IsCurActionLoop()
	{
		return this.m_CurLoop;
	}

	// Token: 0x060086E0 RID: 34528 RVA: 0x0017AD18 File Offset: 0x00179118
	public void Replay()
	{
		if (this.m_CurAnimClipName == null)
		{
			return;
		}
		this.PlayAction(this.m_CurAnimClipName, this.m_CurSpeed, this.m_CurLoop, 0f);
	}

	// Token: 0x060086E1 RID: 34529 RVA: 0x0017AD44 File Offset: 0x00179144
	public bool PlayAction(string acActionName, float fSpeed, bool loop = false, float offset = 0f)
	{
		this.m_CurAnimClipName = acActionName;
		this.m_CurSpeed = fSpeed;
		this.m_CurLoop = loop;
		return null != this.m_AnimDescProxy && this.m_AnimDescProxy.ChangeAction(this.m_CurAnimClipName, this.m_CurLoop, this.m_CurSpeed, offset);
	}

	// Token: 0x060086E2 RID: 34530 RVA: 0x0017AD98 File Offset: 0x00179198
	public void PreloadAction(string[] animList)
	{
		int i = 0;
		int num = animList.Length;
		while (i < num)
		{
			GeAnimDesc geAnimDesc = this._FindAnimDescByName(animList[i]);
			if (null == geAnimDesc.animClipData && !string.IsNullOrEmpty(geAnimDesc.animClipPath))
			{
				geAnimDesc.animClipData = this._LoadAnimtionClip(geAnimDesc.animClipPath, null);
			}
			i++;
		}
	}

	// Token: 0x060086E3 RID: 34531 RVA: 0x0017ADFC File Offset: 0x001791FC
	public void PreloadAction(string anim)
	{
		GeAnimDesc geAnimDesc = this._FindAnimDescByName(anim);
		if (null == geAnimDesc.animClipData && !string.IsNullOrEmpty(geAnimDesc.animClipPath))
		{
			geAnimDesc.animClipData = this._LoadAnimtionClip(geAnimDesc.animClipPath, null);
		}
	}

	// Token: 0x060086E4 RID: 34532 RVA: 0x0017AE48 File Offset: 0x00179248
	public bool IsCurAnimFinished()
	{
		bool result = true;
		if (null != this.m_AnimDescProxy && null != this.m_AnimDescProxy.animInstance)
		{
			AnimationState animationState = this.m_AnimDescProxy.animInstance[this.m_CurAnimClipName];
			if (null != animationState)
			{
				result = (animationState.normalizedTime >= 1f);
			}
		}
		return result;
	}

	// Token: 0x060086E5 RID: 34533 RVA: 0x0017AEB4 File Offset: 0x001792B4
	public void Stop()
	{
		if (null != this.m_AnimDescProxy && null != this.m_AnimDescProxy.animInstance)
		{
			if (this.m_CurAnimClipName == null || this.m_CurAnimClipName == string.Empty)
			{
				return;
			}
			AnimationState animationState = this.m_AnimDescProxy.animInstance[this.m_CurAnimClipName];
			if (animationState != null)
			{
				this.m_AnimDescProxy.animInstance.Stop();
			}
		}
		this.m_CurAnimClipName = string.Empty;
	}

	// Token: 0x060086E6 RID: 34534 RVA: 0x0017AF48 File Offset: 0x00179348
	public void Pause()
	{
		if (this.m_IsPaused)
		{
			return;
		}
		if (null != this.m_AnimDescProxy && null != this.m_AnimDescProxy.animInstance)
		{
			if (this.m_CurAnimClipName == null || this.m_CurAnimClipName == string.Empty)
			{
				return;
			}
			AnimationState animationState = this.m_AnimDescProxy.animInstance[this.m_CurAnimClipName];
			if (null != animationState)
			{
				this.m_PauseTimePos = animationState.time;
				this.m_AnimDescProxy.animInstance.Stop();
			}
		}
		this.m_IsPaused = true;
	}

	// Token: 0x060086E7 RID: 34535 RVA: 0x0017AFF0 File Offset: 0x001793F0
	public void Resume()
	{
		if (!this.m_IsPaused)
		{
			return;
		}
		if (null != this.m_AnimDescProxy && null != this.m_AnimDescProxy.animInstance)
		{
			if (this.m_CurAnimClipName == null || this.m_CurAnimClipName == string.Empty)
			{
				return;
			}
			AnimationState animationState = this.m_AnimDescProxy.animInstance[this.m_CurAnimClipName];
			if (null != animationState)
			{
				animationState.time = this.m_PauseTimePos;
				this.m_AnimDescProxy.animInstance.Play(this.m_CurAnimClipName);
			}
		}
		this.m_IsPaused = false;
	}

	// Token: 0x060086E8 RID: 34536 RVA: 0x0017B09E File Offset: 0x0017949E
	public string GetCurActionName()
	{
		return this.m_CurAnimClipName;
	}

	// Token: 0x060086E9 RID: 34537 RVA: 0x0017B0A8 File Offset: 0x001794A8
	public float GetCurActionOffset()
	{
		if (null != this.m_AnimDescProxy && null != this.m_AnimDescProxy.animInstance)
		{
			AnimationState animationState = this.m_AnimDescProxy.animInstance[this.m_CurAnimClipName];
			if (null != animationState)
			{
				return animationState.time;
			}
		}
		return 0f;
	}

	// Token: 0x060086EA RID: 34538 RVA: 0x0017B10C File Offset: 0x0017950C
	public AnimationClip _LoadAnimtionClip(string path, string animClip)
	{
		string path2;
		if (string.IsNullOrEmpty(animClip))
		{
			path2 = path;
		}
		else
		{
			path2 = string.Format("{0}:{1}", path, animClip);
		}
		return Singleton<AssetLoader>.instance.LoadRes(path2, typeof(AnimationClip), true, 0U).obj as AnimationClip;
	}

	// Token: 0x060086EB RID: 34539 RVA: 0x0017B15C File Offset: 0x0017955C
	protected GeAnimDesc _FindAnimDescByName(string name)
	{
		if (null != this.m_AnimDescProxy && this.m_AnimDescProxy.animDescArray != null)
		{
			int i = 0;
			int num = this.m_AnimDescProxy.animDescArray.Length;
			while (i < num)
			{
				if (this.m_AnimDescProxy.animDescArray[i].animClipName == name)
				{
					return this.m_AnimDescProxy.animDescArray[i];
				}
				i++;
			}
		}
		return GeAnimationManager.sInvalidAnimDesc;
	}

	// Token: 0x060086EC RID: 34540 RVA: 0x0017B1DC File Offset: 0x001795DC
	protected float _CalculateAnimTimeLength(string name)
	{
		float result = 0f;
		GeAnimDesc geAnimDesc = this._FindAnimDescByName(name);
		if (!string.IsNullOrEmpty(geAnimDesc.animClipPath))
		{
			if (null == geAnimDesc.animClipData)
			{
				geAnimDesc.animClipData = this._LoadAnimtionClip(geAnimDesc.animClipPath, null);
			}
			if (null != geAnimDesc.animClipData)
			{
				return geAnimDesc.animClipData.length;
			}
		}
		return result;
	}

	// Token: 0x040040C6 RID: 16582
	public static GeAnimDesc sInvalidAnimDesc = GeAnimDescProxy.sInvalidAnimDesc;

	// Token: 0x040040C7 RID: 16583
	protected string m_CurAnimClipName;

	// Token: 0x040040C8 RID: 16584
	protected float m_CurSpeed = 1f;

	// Token: 0x040040C9 RID: 16585
	protected bool m_CurLoop;

	// Token: 0x040040CA RID: 16586
	protected bool m_IsPaused;

	// Token: 0x040040CB RID: 16587
	protected float m_PauseTimePos;

	// Token: 0x040040CC RID: 16588
	protected GeAnimDescProxy m_AnimDescProxy;
}
