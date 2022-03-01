using System;
using GameClient;

// Token: 0x02000FFB RID: 4091
public class ComNewbieGuideShowImage : ComNewbieGuideBase
{
	// Token: 0x06009BBD RID: 39869 RVA: 0x001E5EEC File Offset: 0x001E42EC
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		this.mProtectTime = 2.2f;
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.mShowImagePath = (args[0] as string);
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

	// Token: 0x06009BBE RID: 39870 RVA: 0x001E5F64 File Offset: 0x001E4364
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (this.mShowImagePath.Length <= 0)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		if (!base.AddShowImage(this.mShowImagePath))
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x04005526 RID: 21798
	public string mShowImagePath = string.Empty;
}
