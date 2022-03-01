using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF3 RID: 4083
public class ComNewbieGuideIntroduction2 : ComNewbieGuideBase
{
	// Token: 0x06009BA1 RID: 39841 RVA: 0x001E56C0 File Offset: 0x001E3AC0
	public override void StartInit(params object[] args)
	{
		this.bOpenAutoClose = false;
		this.mWaitTime = 10f;
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.mTextTips = (args[0] as string);
			}
			if (args.Length >= 2 && (eNewbieGuideAgrsName)args[1] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 3 && args[2] as string != string.Empty)
			{
				this.mHighLightPointPath = (args[2] as string);
			}
			if (args.Length >= 4 && (eNewbieGuideAgrsName)args[3] == eNewbieGuideAgrsName.AutoClose)
			{
				this.bOpenAutoClose = true;
			}
			if (args.Length >= 5)
			{
				this.mWaitTime = (float)args[4];
			}
		}
	}

	// Token: 0x06009BA2 RID: 39842 RVA: 0x001E5784 File Offset: 0x001E3B84
	protected override ComNewbieGuideBase.GuideState _init()
	{
		base.AddIntroductionTips2();
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BA3 RID: 39843 RVA: 0x001E5790 File Offset: 0x001E3B90
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

	// Token: 0x04005519 RID: 21785
	public bool bOpenAutoClose;

	// Token: 0x0400551A RID: 21786
	public float mWaitTime = 10f;
}
