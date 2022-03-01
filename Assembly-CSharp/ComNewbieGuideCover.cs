using System;

// Token: 0x02000FED RID: 4077
public class ComNewbieGuideCover : ComNewbieGuideBase
{
	// Token: 0x06009B83 RID: 39811 RVA: 0x001E4758 File Offset: 0x001E2B58
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		if (args != null && args.Length >= 1)
		{
			this.mFrameType = (args[0] as string);
		}
	}

	// Token: 0x06009B84 RID: 39812 RVA: 0x001E477E File Offset: 0x001E2B7E
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (!base.AddCover())
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}
}
