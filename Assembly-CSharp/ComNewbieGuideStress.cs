using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000FFC RID: 4092
public class ComNewbieGuideStress : ComNewbieGuideBase
{
	// Token: 0x06009BC0 RID: 39872 RVA: 0x001E5FA8 File Offset: 0x001E43A8
	public override void StartInit(params object[] args)
	{
		this.bWait = true;
		this.mWaitTime = 2f;
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.mFrameType = (args[0] as string);
			}
			if (args.Length >= 2)
			{
				this.mComRoot = (args[1] as string);
			}
			if (args.Length >= 3)
			{
				this.bWait = (bool)args[2];
			}
			if (args.Length >= 4)
			{
				this.mWaitTime = (float)args[3];
			}
			if (args.Length >= 5 && (eNewbieGuideAgrsName)args[4] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 6 && (eNewbieGuideAgrsName)args[5] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
			if (args.Length >= 7 && (eNewbieGuideAgrsName)args[6] == eNewbieGuideAgrsName.ResumeBattle)
			{
				this.mTryResumeBattle = true;
			}
		}
	}

	// Token: 0x06009BC1 RID: 39873 RVA: 0x001E608C File Offset: 0x001E448C
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
			return ComNewbieGuideBase.GuideState.Wait;
		}
		Button component = gameBind.GetComponent<Button>(this.mComRoot);
		if (component == null)
		{
			Logger.LogErrorFormat("button is nil with path {0}", new object[]
			{
				this.mComRoot
			});
			return ComNewbieGuideBase.GuideState.Exception;
		}
		if (!base.AddStress(component.gameObject))
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BC2 RID: 39874 RVA: 0x001E6140 File Offset: 0x001E4540
	protected override void _update()
	{
		if (this.bWait)
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

	// Token: 0x04005527 RID: 21799
	public bool bWait = true;

	// Token: 0x04005528 RID: 21800
	public float mWaitTime = 2f;
}
