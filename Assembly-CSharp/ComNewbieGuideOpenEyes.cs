using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF6 RID: 4086
public class ComNewbieGuideOpenEyes : ComNewbieGuideBase
{
	// Token: 0x06009BAD RID: 39853 RVA: 0x001E5A08 File Offset: 0x001E3E08
	public override void StartInit(params object[] args)
	{
		this.mWaitTime = 4f;
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.mWaitTime = (float)args[0];
			}
			if (args.Length >= 2 && (eNewbieGuideAgrsName)args[1] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 3 && (eNewbieGuideAgrsName)args[2] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
		}
	}

	// Token: 0x06009BAE RID: 39854 RVA: 0x001E5A80 File Offset: 0x001E3E80
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (!base.AddOpenEyes())
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BAF RID: 39855 RVA: 0x001E5A90 File Offset: 0x001E3E90
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

	// Token: 0x04005520 RID: 21792
	public float mWaitTime = 3.3f;
}
