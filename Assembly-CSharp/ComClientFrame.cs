using System;
using System.Diagnostics;
using GameClient;
using UnityEngine;

// Token: 0x02000DA8 RID: 3496
public class ComClientFrame : MonoBehaviour, IComClientFrame
{
	// Token: 0x06008D95 RID: 36245 RVA: 0x001A587D File Offset: 0x001A3C7D
	private void Awake()
	{
		if (this.mNeedGlass)
		{
		}
	}

	// Token: 0x06008D96 RID: 36246 RVA: 0x001A588A File Offset: 0x001A3C8A
	private void OnDestroy()
	{
		this._destroyGlass();
	}

	// Token: 0x06008D97 RID: 36247 RVA: 0x001A5892 File Offset: 0x001A3C92
	private void OnTransformParentChanged()
	{
		if (this.mNeedGlass)
		{
			this._createGlass();
		}
	}

	// Token: 0x06008D98 RID: 36248 RVA: 0x001A58A5 File Offset: 0x001A3CA5
	private void OnEnable()
	{
		if (this.mNeedGlass)
		{
			this._createGlass();
		}
	}

	// Token: 0x06008D99 RID: 36249 RVA: 0x001A58B8 File Offset: 0x001A3CB8
	private void OnDisable()
	{
		this._destroyGlass();
	}

	// Token: 0x06008D9A RID: 36250 RVA: 0x001A58C0 File Offset: 0x001A3CC0
	private void _createGlass()
	{
	}

	// Token: 0x06008D9B RID: 36251 RVA: 0x001A58C2 File Offset: 0x001A3CC2
	private void _destroyGlass()
	{
		if (null != this.mGlassBg)
		{
			Object.Destroy(this.mGlassBg);
			this.mGlassBg = null;
		}
	}

	// Token: 0x06008D9C RID: 36252 RVA: 0x001A58E8 File Offset: 0x001A3CE8
	[Conditional("UNITY_EDITOR")]
	private void _updateRoot()
	{
		if (Application.isPlaying)
		{
			if (this.mLayer == FrameLayer.LayerMax)
			{
				this.mLayer = FrameLayer.Middle;
			}
			Type type = Type.GetType(this.mCurrentFrameName);
			if (type != null)
			{
				IClientFrame frame = Singleton<ClientSystemManager>.instance.GetFrame(type);
				if (frame != null)
				{
					frame.UpdateRoot();
				}
				else
				{
					Logger.LogErrorFormat("can't find {0}", new object[]
					{
						this.mCurrentFrameName
					});
				}
			}
		}
	}

	// Token: 0x06008D9D RID: 36253 RVA: 0x001A595A File Offset: 0x001A3D5A
	[Conditional("UNITY_EDITOR")]
	private void _updateMutexLayer()
	{
	}

	// Token: 0x06008D9E RID: 36254 RVA: 0x001A595C File Offset: 0x001A3D5C
	public void OnValidate()
	{
	}

	// Token: 0x06008D9F RID: 36255 RVA: 0x001A595E File Offset: 0x001A3D5E
	public int GetZOrder()
	{
		return this.mZOrder;
	}

	// Token: 0x06008DA0 RID: 36256 RVA: 0x001A5966 File Offset: 0x001A3D66
	public void SetCurrentFrame(string name)
	{
		this.mCurrentFrameName = name;
	}

	// Token: 0x06008DA1 RID: 36257 RVA: 0x001A596F File Offset: 0x001A3D6F
	public string GetGroupTag()
	{
		return this.mGroupTag;
	}

	// Token: 0x06008DA2 RID: 36258 RVA: 0x001A5977 File Offset: 0x001A3D77
	public bool IsNeedFade()
	{
		return this.mHiddenNeedFade;
	}

	// Token: 0x06008DA3 RID: 36259 RVA: 0x001A597F File Offset: 0x001A3D7F
	public FrameLayer GetLayer()
	{
		return this.mLayer;
	}

	// Token: 0x06008DA4 RID: 36260 RVA: 0x001A5987 File Offset: 0x001A3D87
	public bool IsNeedClearWhenChangeScene()
	{
		return this.mClearWhenChangeScene;
	}

	// Token: 0x06008DA5 RID: 36261 RVA: 0x001A598F File Offset: 0x001A3D8F
	public void SetGroupTag(string tag)
	{
		this.mGroupTag = tag;
	}

	// Token: 0x06008DA6 RID: 36262 RVA: 0x001A5998 File Offset: 0x001A3D98
	public void SetIsNeedClearWhenChangeScene(bool bFlag)
	{
		this.mClearWhenChangeScene = bFlag;
	}

	// Token: 0x06008DA7 RID: 36263 RVA: 0x001A59A1 File Offset: 0x001A3DA1
	public bool IsInitWithGameBindSystem()
	{
		return this.bInitWithGameBindSystem;
	}

	// Token: 0x06008DA8 RID: 36264 RVA: 0x001A59A9 File Offset: 0x001A3DA9
	public eFrameType GetFrameType()
	{
		return this.mFrameType;
	}

	// Token: 0x06008DA9 RID: 36265 RVA: 0x001A59B1 File Offset: 0x001A3DB1
	public bool IsFullScreenFrameNeedBeClose()
	{
		return this.bIsFullScreenFrameNeedBeClosed;
	}

	// Token: 0x06008DAA RID: 36266 RVA: 0x001A59B9 File Offset: 0x001A3DB9
	public bool IsFullScreenFrame()
	{
		return eFrameType.FullScreen == this.mFrameType;
	}

	// Token: 0x0400463C RID: 17980
	public FrameLayer mLayer = FrameLayer.Middle;

	// Token: 0x0400463D RID: 17981
	public int mZOrder = -1;

	// Token: 0x0400463E RID: 17982
	public bool mHiddenNeedFade;

	// Token: 0x0400463F RID: 17983
	public bool mNeedGlass;

	// Token: 0x04004640 RID: 17984
	public string mGroupTag = string.Empty;

	// Token: 0x04004641 RID: 17985
	public string mCurrentFrameName = string.Empty;

	// Token: 0x04004642 RID: 17986
	public bool mClearWhenChangeScene;

	// Token: 0x04004643 RID: 17987
	private GameObject mGlassBg;

	// Token: 0x04004644 RID: 17988
	public eFrameType mFrameType;

	// Token: 0x04004645 RID: 17989
	public bool bIsFullScreenFrameNeedBeClosed;

	// Token: 0x04004646 RID: 17990
	public bool bUseFadeIn;

	// Token: 0x04004647 RID: 17991
	public bool bUseFadeOut;

	// Token: 0x04004648 RID: 17992
	public bool bUseBlackMask;

	// Token: 0x04004649 RID: 17993
	public bool bBlackMaskClickAutoClose;

	// Token: 0x0400464A RID: 17994
	public bool bNewCloseNeedGC;

	// Token: 0x0400464B RID: 17995
	public bool bInitWithGameBindSystem = true;
}
