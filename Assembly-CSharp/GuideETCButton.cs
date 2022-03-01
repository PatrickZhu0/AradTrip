using System;

// Token: 0x0200100F RID: 4111
[Serializable]
public class GuideETCButton : IUnitData
{
	// Token: 0x06009C33 RID: 39987 RVA: 0x001E86EB File Offset: 0x001E6AEB
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.ETC_BUTTON;
	}

	// Token: 0x06009C34 RID: 39988 RVA: 0x001E86EE File Offset: 0x001E6AEE
	public Type objType()
	{
		return typeof(GuideETCButton);
	}

	// Token: 0x06009C35 RID: 39989 RVA: 0x001E86FA File Offset: 0x001E6AFA
	public object[] getArgs()
	{
		return new object[]
		{
			this.mButtonName,
			this.mAnchor,
			this.mContent
		};
	}

	// Token: 0x0400559C RID: 21916
	public string mButtonName;

	// Token: 0x0400559D RID: 21917
	public ComNewbieGuideBase.eNewbieGuideAnchor mAnchor;

	// Token: 0x0400559E RID: 21918
	public string mContent;
}
