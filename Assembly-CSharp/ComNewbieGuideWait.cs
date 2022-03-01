using System;
using GameClient;
using UnityEngine;

// Token: 0x02001000 RID: 4096
public class ComNewbieGuideWait : ComNewbieGuideBase
{
	// Token: 0x06009BCB RID: 39883 RVA: 0x001E64BC File Offset: 0x001E48BC
	public override void StartInit(params object[] args)
	{
		this.mWaitTime = 0f;
		this.mbPathThrough = false;
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.mWaitTime = (float)args[0];
			}
			if (args.Length >= 2)
			{
				this.mbPathThrough = (bool)args[1];
			}
			if (args.Length >= 3 && (eNewbieGuideAgrsName)args[2] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 4 && (eNewbieGuideAgrsName)args[3] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
			if (args.Length >= 5 && (eNewbieGuideAgrsName)args[4] == eNewbieGuideAgrsName.ResumeBattle)
			{
				this.mTryResumeBattle = true;
			}
		}
	}

	// Token: 0x06009BCC RID: 39884 RVA: 0x001E6570 File Offset: 0x001E4970
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (this.mFrameType == string.Empty || this.mComRoot == string.Empty)
		{
			base.AddWaitTips(null, this.mbPathThrough);
			return ComNewbieGuideBase.GuideState.Normal;
		}
		IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
		if (!instance.IsFrameOpen(this.mFrameType))
		{
			return ComNewbieGuideBase.GuideState.Wait;
		}
		IGameBind gameBind = instance.GetFrame(this.mFrameType) as IGameBind;
		if (gameBind == null)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		RectTransform component = gameBind.GetComponent<RectTransform>(this.mComRoot);
		if (component == null)
		{
			Logger.LogErrorFormat("SourceRect is nil with path {0}", new object[]
			{
				this.mComRoot
			});
			return ComNewbieGuideBase.GuideState.Exception;
		}
		GameObject root = base.AddWaitTips(component.gameObject, this.mbPathThrough);
		if (this.mTextTips.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BCD RID: 39885 RVA: 0x001E6664 File Offset: 0x001E4A64
	protected override void _update()
	{
		if (this.mWaitTime > 0f)
		{
			this.mWaitTime -= Time.deltaTime;
		}
		else if (this.mGuideControl != null)
		{
			this.mGuideControl.ControlComplete();
		}
	}

	// Token: 0x0400552A RID: 21802
	public float mWaitTime;

	// Token: 0x0400552B RID: 21803
	public bool mbPathThrough;
}
