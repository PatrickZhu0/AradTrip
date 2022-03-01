using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x02000CC7 RID: 3271
public class GeAnimDescProxy : MonoBehaviour
{
	// Token: 0x06008689 RID: 34441 RVA: 0x0017894C File Offset: 0x00176D4C
	public GeAnimDescProxy()
	{
		if (GeAnimDescProxy.<>f__mg$cache0 == null)
		{
			GeAnimDescProxy.<>f__mg$cache0 = new OnAssetLoadSuccess(GeAnimDescProxy._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = GeAnimDescProxy.<>f__mg$cache0;
		if (GeAnimDescProxy.<>f__mg$cache1 == null)
		{
			GeAnimDescProxy.<>f__mg$cache1 = new OnAssetLoadFailure(GeAnimDescProxy._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, GeAnimDescProxy.<>f__mg$cache1);
		this.m_ChangeActionContext = new GeAnimDescProxy.ChangeActionContext();
		base..ctor();
	}

	// Token: 0x17001818 RID: 6168
	// (get) Token: 0x0600868B RID: 34443 RVA: 0x001789D6 File Offset: 0x00176DD6
	// (set) Token: 0x0600868A RID: 34442 RVA: 0x001789C7 File Offset: 0x00176DC7
	public GeAnimDesc[] animDescArray
	{
		get
		{
			return this.m_AnimDescArray;
		}
		set
		{
			if (value != null)
			{
				this.m_AnimDescArray = value;
			}
		}
	}

	// Token: 0x17001819 RID: 6169
	// (get) Token: 0x0600868D RID: 34445 RVA: 0x001789ED File Offset: 0x00176DED
	// (set) Token: 0x0600868C RID: 34444 RVA: 0x001789DE File Offset: 0x00176DDE
	public string[] animDataResFile
	{
		get
		{
			return this.m_AnimDataResFile;
		}
		set
		{
			if (value != null)
			{
				this.m_AnimDataResFile = value;
			}
		}
	}

	// Token: 0x1700181A RID: 6170
	// (get) Token: 0x0600868F RID: 34447 RVA: 0x00178A0A File Offset: 0x00176E0A
	// (set) Token: 0x0600868E RID: 34446 RVA: 0x001789F5 File Offset: 0x00176DF5
	public Animation animInstance
	{
		get
		{
			return this.m_Animaion;
		}
		set
		{
			if (null != value)
			{
				this.m_Animaion = value;
			}
		}
	}

	// Token: 0x06008690 RID: 34448 RVA: 0x00178A14 File Offset: 0x00176E14
	public void GenAnimDesc()
	{
		List<GeAnimDesc> list = new List<GeAnimDesc>();
		this._ReinitAnimationDesc(ref list);
		this.animDescArray = list.ToArray();
		this.m_Animaion = base.gameObject.GetComponent<Animation>();
		if (null == this.m_Animaion)
		{
			this.m_Animaion = base.gameObject.AddComponent<Animation>();
		}
		if (null != this.m_Animaion)
		{
			this.m_Animaion.cullingType = 1;
		}
	}

	// Token: 0x06008691 RID: 34449 RVA: 0x00178A8C File Offset: 0x00176E8C
	public bool ChangeAction(string name, bool loop, float speed, float offset = 0f)
	{
		if (EngineConfig.useAsyncLoadAnim)
		{
			if (null != this.m_Animaion)
			{
				GeAnimClipPlayMode geAnimClipPlayMode = GeAnimClipPlayMode.AnimPlayOnce;
				AnimationState animationState = this.m_Animaion[name];
				if (animationState == null)
				{
					GeAnimDesc geAnimDesc = this.FindAnimDescByName(name);
					geAnimClipPlayMode = geAnimDesc.animPlayMode;
					if (null == geAnimDesc.animClipData && !string.IsNullOrEmpty(geAnimDesc.animClipPath))
					{
						GeAnimDescProxy.AsyncLoadContext asyncLoadContext = new GeAnimDescProxy.AsyncLoadContext();
						asyncLoadContext.m_AnimDesc = geAnimDesc;
						asyncLoadContext.m_This = this;
						this.m_ChangeActionContext.m_AnimName = name;
						this.m_ChangeActionContext.m_IsLoop = loop;
						this.m_ChangeActionContext.m_Speed = speed;
						this.m_ChangeActionContext.m_Offset = offset;
						this.m_ChangeActionContext.m_TimeStamp = DateTime.Now.Ticks;
						this.m_ChangeActionContext.m_IsValid = true;
						AssetLoader.LoadResAsync(geAnimDesc.animClipPath, typeof(AnimationClip), this.m_AssetLoadCallbacks, asyncLoadContext, 1U, 0U);
						return true;
					}
					if (null != geAnimDesc.animClipData && geAnimDesc.animClipData.legacy)
					{
						this.animInstance.AddClip(geAnimDesc.animClipData, geAnimDesc.animClipName);
						animationState = this.animInstance[name];
					}
				}
				if (null != animationState)
				{
					this.m_ChangeActionContext.m_IsValid = false;
					animationState.wrapMode = ((!loop) ? 8 : 2);
					if (!loop)
					{
						animationState.wrapMode = ((geAnimClipPlayMode != GeAnimClipPlayMode.AnimPlayLoop) ? 8 : 2);
					}
					if (animationState.speed != speed)
					{
						animationState.speed = speed;
					}
					this.animInstance.Stop();
					animationState.time = offset;
					this.animInstance.Play(name);
					return true;
				}
			}
			return false;
		}
		if (null != this.m_Animaion)
		{
			GeAnimClipPlayMode geAnimClipPlayMode2 = GeAnimClipPlayMode.AnimPlayOnce;
			AnimationState animationState2 = this.m_Animaion[name];
			if (animationState2 == null)
			{
				GeAnimDesc geAnimDesc2 = this.FindAnimDescByName(name);
				geAnimClipPlayMode2 = geAnimDesc2.animPlayMode;
				if (null == geAnimDesc2.animClipData && !string.IsNullOrEmpty(geAnimDesc2.animClipPath))
				{
					geAnimDesc2.animClipData = this._LoadAnimtionClip(geAnimDesc2.animClipPath, null);
				}
				if (null != geAnimDesc2.animClipData && geAnimDesc2.animClipData.legacy)
				{
					this.animInstance.AddClip(geAnimDesc2.animClipData, geAnimDesc2.animClipName);
					animationState2 = this.animInstance[name];
				}
			}
			if (null != animationState2)
			{
				animationState2.wrapMode = ((!loop) ? 8 : 2);
				if (!loop)
				{
					animationState2.wrapMode = ((geAnimClipPlayMode2 != GeAnimClipPlayMode.AnimPlayLoop) ? 8 : 2);
				}
				if (animationState2.speed != speed)
				{
					animationState2.speed = speed;
				}
				this.animInstance.Stop();
				animationState2.time = offset;
				this.animInstance.Play(name);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06008692 RID: 34450 RVA: 0x00178D84 File Offset: 0x00177184
	private bool _ChangeActionImmediate(string name, bool loop, float speed, float offset)
	{
		if (null != this.m_Animaion)
		{
			GeAnimClipPlayMode geAnimClipPlayMode = GeAnimClipPlayMode.AnimPlayOnce;
			AnimationState animationState = this.m_Animaion[name];
			if (animationState == null)
			{
				GeAnimDesc geAnimDesc = this.FindAnimDescByName(name);
				geAnimClipPlayMode = geAnimDesc.animPlayMode;
				if (null != geAnimDesc.animClipData && geAnimDesc.animClipData.legacy)
				{
					this.animInstance.AddClip(geAnimDesc.animClipData, geAnimDesc.animClipName);
					animationState = this.animInstance[name];
				}
			}
			if (null != animationState)
			{
				animationState.wrapMode = ((!loop) ? 8 : 2);
				if (!loop)
				{
					animationState.wrapMode = ((geAnimClipPlayMode != GeAnimClipPlayMode.AnimPlayLoop) ? 8 : 2);
				}
				if (animationState.speed != speed)
				{
					animationState.speed = speed;
				}
				this.animInstance.Stop();
				animationState.time = offset;
				this.animInstance.Play(name);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06008693 RID: 34451 RVA: 0x00178E80 File Offset: 0x00177280
	public void PreloadAction(string[] animList)
	{
		int i = 0;
		int num = animList.Length;
		while (i < num)
		{
			this.PreloadAction(animList[i]);
			i++;
		}
	}

	// Token: 0x06008694 RID: 34452 RVA: 0x00178EAC File Offset: 0x001772AC
	public void PreloadAction(string anim)
	{
		int i = 0;
		int num = this.m_AnimDescArray.Length;
		while (i < num)
		{
			if (this.m_AnimDescArray[i].animClipName.Equals(anim))
			{
				this.m_AnimDescArray[i].animClipData = this._LoadAnimtionClip(this.m_AnimDescArray[i].animClipPath, null);
			}
			i++;
		}
	}

	// Token: 0x06008695 RID: 34453 RVA: 0x00178F10 File Offset: 0x00177310
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

	// Token: 0x06008696 RID: 34454 RVA: 0x00178F60 File Offset: 0x00177360
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		if (userData == null)
		{
			TMDebug.LogErrorFormat("User data can not be null!", new object[0]);
			return;
		}
		GeAnimDescProxy.AsyncLoadContext asyncLoadContext = userData as GeAnimDescProxy.AsyncLoadContext;
		if (asyncLoadContext == null)
		{
			TMDebug.LogErrorFormat("User data type '{0}' is NOT AsyncLoadContext!", new object[0]);
			return;
		}
		if (asset == null)
		{
			TMDebug.LogErrorFormat("Asset '{0}' load error!", new object[]
			{
				assetPath
			});
			return;
		}
		AnimationClip animationClip = asset as AnimationClip;
		if (null == animationClip)
		{
			TMDebug.LogErrorFormat("Asset '{0}' is nil or type '{1}' error!", new object[]
			{
				assetPath,
				asset.GetType()
			});
			return;
		}
		asyncLoadContext.m_AnimDesc.animClipData = animationClip;
		if (asyncLoadContext.m_This.m_ChangeActionContext.m_IsValid && asyncLoadContext.m_AnimDesc.animClipName == asyncLoadContext.m_This.m_ChangeActionContext.m_AnimName)
		{
			float num = TMEngine.Runtime.Utility.Time.TicksToSeconds(DateTime.Now.Ticks - asyncLoadContext.m_This.m_ChangeActionContext.m_TimeStamp);
			asyncLoadContext.m_This._ChangeActionImmediate(asyncLoadContext.m_This.m_ChangeActionContext.m_AnimName, asyncLoadContext.m_This.m_ChangeActionContext.m_IsLoop, asyncLoadContext.m_This.m_ChangeActionContext.m_Speed, asyncLoadContext.m_This.m_ChangeActionContext.m_Offset + num);
			asyncLoadContext.m_This.m_ChangeActionContext.m_IsValid = false;
		}
	}

	// Token: 0x06008697 RID: 34455 RVA: 0x001790B9 File Offset: 0x001774B9
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
	}

	// Token: 0x06008698 RID: 34456 RVA: 0x001790BB File Offset: 0x001774BB
	private void _LoadAnimationClipAsync(GeAnimDesc animDesc)
	{
	}

	// Token: 0x06008699 RID: 34457 RVA: 0x001790C0 File Offset: 0x001774C0
	protected void _ReinitAnimationDesc(ref List<GeAnimDesc> animClipDescList)
	{
		List<GeAnimDescProxy.AnimFBXDesc> list = new List<GeAnimDescProxy.AnimFBXDesc>();
		List<GeAnimDescProxy.AnimClipDesc> list2 = new List<GeAnimDescProxy.AnimClipDesc>();
		int i = 0;
		int num = this.m_AnimDataResFile.Length;
		while (i < num)
		{
			string extension = Path.GetExtension(this.m_AnimDataResFile[i]);
			if (extension.Contains("fbx") || extension.Contains("FBX"))
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.m_AnimDataResFile[i], true, 0U);
				if (!(null == gameObject))
				{
					list.Add(new GeAnimDescProxy.AnimFBXDesc
					{
						m_Anim = gameObject.GetComponent<Animation>(),
						m_AnimFile = this.m_AnimDataResFile[i]
					});
				}
			}
			else if (extension.Contains("anim") || extension.Contains("ANIM"))
			{
				AnimationClip animationClip = Singleton<AssetLoader>.instance.LoadRes(this.m_AnimDataResFile[i], typeof(AnimationClip), true, 0U).obj as AnimationClip;
				if (!(null == animationClip))
				{
					list2.Add(new GeAnimDescProxy.AnimClipDesc
					{
						m_AnimClip = animationClip,
						m_AnimClipFile = this.m_AnimDataResFile[i]
					});
				}
			}
			i++;
		}
		int j = 0;
		int count = list2.Count;
		while (j < count)
		{
			GeAnimDescProxy.AnimClipDesc animClipDesc = list2[j];
			if (!this._HasAnimClipDesc(animClipDesc.m_AnimClip.name, animClipDescList))
			{
				animClipDescList.Add(new GeAnimDesc(animClipDesc.m_AnimClip.name, animClipDesc.m_AnimClip.name.GetHashCode(), (animClipDesc.m_AnimClip.wrapMode != 2) ? GeAnimClipPlayMode.AnimPlayOnce : GeAnimClipPlayMode.AnimPlayLoop, animClipDesc.m_AnimClip.length, animClipDesc.m_AnimClip, animClipDesc.m_AnimClipFile));
			}
			j++;
		}
		Animation[] array = new Animation[list.Count];
		int k = 0;
		int num2 = array.Length;
		while (k < num2)
		{
			array[k] = list[k].m_Anim;
			k++;
		}
		if (list.Count > 0)
		{
			for (int l = 0; l < list.Count; l++)
			{
				IEnumerator enumerator = list[l].m_Anim.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						AnimationState animationState = (AnimationState)obj;
						if (!this._HasAnimClipDesc(animationState.name, animClipDescList))
						{
							animClipDescList.Add(new GeAnimDesc(animationState.name, animationState.name.GetHashCode(), (animationState.wrapMode != 2) ? GeAnimClipPlayMode.AnimPlayOnce : GeAnimClipPlayMode.AnimPlayLoop, this._CalculateAnimTimeLength(array, animationState.name), animationState.clip, list[l].m_AnimFile));
						}
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
	}

	// Token: 0x0600869A RID: 34458 RVA: 0x001793D0 File Offset: 0x001777D0
	protected float _CalculateAnimTimeLength(Animation[] anis, string name)
	{
		float num = 0f;
		for (int i = 0; i < anis.Length; i++)
		{
			if (!(null == anis[i]))
			{
				AnimationClip clip = anis[i].GetClip(name);
				if (null != clip)
				{
					num = Mathf.Max(clip.length, num);
				}
			}
		}
		return num;
	}

	// Token: 0x0600869B RID: 34459 RVA: 0x00179430 File Offset: 0x00177830
	protected bool _HasAnimClipDesc(string clipName, List<GeAnimDesc> animClipDescLis)
	{
		for (int i = 0; i < animClipDescLis.Count; i++)
		{
			if (animClipDescLis[i].animClipName.Equals(clipName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600869C RID: 34460 RVA: 0x00179470 File Offset: 0x00177870
	public GeAnimDesc FindAnimDescByName(string name)
	{
		if (this.animDescArray != null)
		{
			int i = 0;
			int num = this.animDescArray.Length;
			while (i < num)
			{
				if (this.animDescArray[i].animClipName == name)
				{
					return this.animDescArray[i];
				}
				i++;
			}
		}
		return GeAnimDescProxy.sInvalidAnimDesc;
	}

	// Token: 0x04004083 RID: 16515
	[NonSerialized]
	public static GeAnimDesc sInvalidAnimDesc = new GeAnimDesc(string.Empty, -1, GeAnimClipPlayMode.AnimPlayOnce, 0f, null, null);

	// Token: 0x04004084 RID: 16516
	[SerializeField]
	private GeAnimDesc[] m_AnimDescArray = new GeAnimDesc[0];

	// Token: 0x04004085 RID: 16517
	[SerializeField]
	private Animation m_Animaion;

	// Token: 0x04004086 RID: 16518
	[SerializeField]
	private string[] m_AnimDataResFile = new string[0];

	// Token: 0x04004087 RID: 16519
	[NonSerialized]
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x04004088 RID: 16520
	[NonSerialized]
	private GeAnimDescProxy.ChangeActionContext m_ChangeActionContext;

	// Token: 0x04004089 RID: 16521
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x0400408A RID: 16522
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;

	// Token: 0x02000CC8 RID: 3272
	private class ChangeActionContext
	{
		// Token: 0x0400408B RID: 16523
		public long m_TimeStamp;

		// Token: 0x0400408C RID: 16524
		public string m_AnimName;

		// Token: 0x0400408D RID: 16525
		public bool m_IsLoop;

		// Token: 0x0400408E RID: 16526
		public float m_Speed;

		// Token: 0x0400408F RID: 16527
		public float m_Offset;

		// Token: 0x04004090 RID: 16528
		public bool m_IsValid;
	}

	// Token: 0x02000CC9 RID: 3273
	private class AsyncLoadContext
	{
		// Token: 0x04004091 RID: 16529
		public GeAnimDesc m_AnimDesc;

		// Token: 0x04004092 RID: 16530
		public GeAnimDescProxy m_This;
	}

	// Token: 0x02000CCA RID: 3274
	protected class AnimClipDesc
	{
		// Token: 0x04004093 RID: 16531
		public AnimationClip m_AnimClip;

		// Token: 0x04004094 RID: 16532
		public string m_AnimClipFile;
	}

	// Token: 0x02000CCB RID: 3275
	protected class AnimFBXDesc
	{
		// Token: 0x04004095 RID: 16533
		public Animation m_Anim;

		// Token: 0x04004096 RID: 16534
		public string m_AnimFile;
	}
}
