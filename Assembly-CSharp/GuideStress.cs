using System;
using GameClient;

// Token: 0x02001015 RID: 4117
[Serializable]
public class GuideStress : IUnitData
{
	// Token: 0x06009C4B RID: 40011 RVA: 0x001E8986 File Offset: 0x001E6D86
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.STRESS;
	}

	// Token: 0x06009C4C RID: 40012 RVA: 0x001E898A File Offset: 0x001E6D8A
	public Type objType()
	{
		return typeof(GuideStress);
	}

	// Token: 0x06009C4D RID: 40013 RVA: 0x001E8998 File Offset: 0x001E6D98
	public object[] getArgs()
	{
		return new object[]
		{
			this.mFrameType,
			this.mComRoot,
			this.mWaitTime,
			this.mSaveBoot,
			this.mTryPauseBattle,
			this.mTryResumeBattle
		};
	}

	// Token: 0x040055C0 RID: 21952
	public string mFrameType;

	// Token: 0x040055C1 RID: 21953
	public string mComRoot;

	// Token: 0x040055C2 RID: 21954
	public float mWaitTime;

	// Token: 0x040055C3 RID: 21955
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055C4 RID: 21956
	public eNewbieGuideAgrsName mTryPauseBattle;

	// Token: 0x040055C5 RID: 21957
	public eNewbieGuideAgrsName mTryResumeBattle;
}
