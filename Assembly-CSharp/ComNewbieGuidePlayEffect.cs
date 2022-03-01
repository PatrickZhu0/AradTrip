using System;
using GameClient;
using UnityEngine;

// Token: 0x02000FF9 RID: 4089
public class ComNewbieGuidePlayEffect : ComNewbieGuideBase
{
	// Token: 0x06009BB7 RID: 39863 RVA: 0x001E5DC8 File Offset: 0x001E41C8
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.LoadResFile = (args[0] as string);
			}
			if (args.Length >= 2 && (eNewbieGuideAgrsName)args[1] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 3)
			{
				this.mWaitTime = (float)args[2];
			}
		}
	}

	// Token: 0x06009BB8 RID: 39864 RVA: 0x001E5E2E File Offset: 0x001E422E
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (!base.AddEffect(this.LoadResFile))
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x06009BB9 RID: 39865 RVA: 0x001E5E44 File Offset: 0x001E4244
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

	// Token: 0x04005524 RID: 21796
	public string LoadResFile = string.Empty;

	// Token: 0x04005525 RID: 21797
	public float mWaitTime;
}
