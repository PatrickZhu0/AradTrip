using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF5 RID: 4085
public class ComNewbieGuideNewIconUnlock : ComNewbieGuideBase
{
	// Token: 0x06009BA9 RID: 39849 RVA: 0x001E58B0 File Offset: 0x001E3CB0
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.LoadResFile = (args[0] as string);
			}
			if (args.Length >= 2)
			{
				this.TargetRootPath = (args[1] as string);
			}
			if (args.Length >= 3)
			{
				this.IconPath = (args[2] as string);
			}
			if (args.Length >= 4)
			{
				this.IconName = (args[3] as string);
			}
			if (args.Length >= 5)
			{
				this.mWaitTime = (float)args[4];
			}
			if (args.Length >= 6 && (eNewbieGuideAgrsName)args[5] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 7 && (eNewbieGuideAgrsName)args[6] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
		}
	}

	// Token: 0x06009BAA RID: 39850 RVA: 0x001E5979 File Offset: 0x001E3D79
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (!base.AddNewIconUnlock(this.LoadResFile, this.TargetRootPath, this.IconPath, this.IconName))
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BAB RID: 39851 RVA: 0x001E59A4 File Offset: 0x001E3DA4
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

	// Token: 0x0400551B RID: 21787
	public float mWaitTime;

	// Token: 0x0400551C RID: 21788
	public string LoadResFile = string.Empty;

	// Token: 0x0400551D RID: 21789
	public string TargetRootPath = string.Empty;

	// Token: 0x0400551E RID: 21790
	public string IconPath = string.Empty;

	// Token: 0x0400551F RID: 21791
	public string IconName = string.Empty;
}
