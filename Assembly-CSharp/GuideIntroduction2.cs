using System;
using GameClient;

// Token: 0x02001012 RID: 4114
[Serializable]
public class GuideIntroduction2 : IUnitData
{
	// Token: 0x06009C3F RID: 39999 RVA: 0x001E880C File Offset: 0x001E6C0C
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.INTRODUCTION2;
	}

	// Token: 0x06009C40 RID: 40000 RVA: 0x001E8810 File Offset: 0x001E6C10
	public Type objType()
	{
		return typeof(GuideIntroduction2);
	}

	// Token: 0x06009C41 RID: 40001 RVA: 0x001E881C File Offset: 0x001E6C1C
	public object[] getArgs()
	{
		return new object[]
		{
			this.mTextTips,
			this.mSaveBoot,
			this.mHighLightPointPath,
			this.mAutoClose,
			this.mWaitTime
		};
	}

	// Token: 0x040055AB RID: 21931
	public string mTextTips;

	// Token: 0x040055AC RID: 21932
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055AD RID: 21933
	public string mHighLightPointPath;

	// Token: 0x040055AE RID: 21934
	public eNewbieGuideAgrsName mAutoClose;

	// Token: 0x040055AF RID: 21935
	public float mWaitTime;
}
