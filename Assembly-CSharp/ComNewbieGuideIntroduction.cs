using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF2 RID: 4082
public class ComNewbieGuideIntroduction : ComNewbieGuideBase
{
	// Token: 0x06009B9D RID: 39837 RVA: 0x001E541C File Offset: 0x001E381C
	public override void StartInit(params object[] args)
	{
		this.bOpenAutoClose = false;
		this.mWaitTime = 10f;
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 2)
			{
				this.mFrameType = (args[0] as string);
				this.mComRoot = (args[1] as string);
			}
			if (args.Length >= 3)
			{
				this.mTextTips = (args[2] as string);
			}
			if (args.Length >= 4)
			{
				this.mAnchor = (ComNewbieGuideBase.eNewbieGuideAnchor)args[3];
			}
			if (args.Length >= 5)
			{
				this.mTextTipType = (TextTipType)args[4];
			}
			if (args.Length >= 6)
			{
				this.mLocalPos = (Vector3)args[5];
			}
			if (args.Length >= 7 && (eNewbieGuideAgrsName)args[6] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 8 && (eNewbieGuideAgrsName)args[7] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
			if (args.Length >= 9 && args[8] as string != string.Empty)
			{
				this.mHighLightPointPath = (args[8] as string);
			}
			if (args.Length >= 10 && (eNewbieGuideAgrsName)args[9] == eNewbieGuideAgrsName.AutoClose)
			{
				this.bOpenAutoClose = true;
			}
			if (args.Length >= 11)
			{
				this.mWaitTime = (float)args[10];
			}
		}
	}

	// Token: 0x06009B9E RID: 39838 RVA: 0x001E5570 File Offset: 0x001E3970
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IGameBind gameBind = null;
		if (this.mFrameType == "ClientSystemBattle")
		{
			gameBind = (Singleton<ClientSystemManager>.instance.CurrentSystem as IGameBind);
		}
		else
		{
			IClientFrameManager instance = Singleton<ClientSystemManager>.instance;
			if (instance.IsFrameOpen(this.mFrameType))
			{
				gameBind = (instance.GetFrame(this.mFrameType) as IGameBind);
			}
		}
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
		GameObject root = base.AddIntroductionTips(component.gameObject);
		if (this.mTextTips.Length > 0)
		{
			base.AddTextTips(root, this.mAnchor, this.mTextTips, this.mTextTipType, this.mLocalPos);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009B9F RID: 39839 RVA: 0x001E5650 File Offset: 0x001E3A50
	protected override void _update()
	{
		if (this.bOpenAutoClose)
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
	}

	// Token: 0x04005517 RID: 21783
	public bool bOpenAutoClose;

	// Token: 0x04005518 RID: 21784
	public float mWaitTime = 10f;
}
