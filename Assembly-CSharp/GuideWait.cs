using System;
using GameClient;

// Token: 0x02001017 RID: 4119
[Serializable]
public class GuideWait : IUnitData
{
	// Token: 0x06009C53 RID: 40019 RVA: 0x001E8A4D File Offset: 0x001E6E4D
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.WAIT;
	}

	// Token: 0x06009C54 RID: 40020 RVA: 0x001E8A51 File Offset: 0x001E6E51
	public Type objType()
	{
		return typeof(GuideWait);
	}

	// Token: 0x06009C55 RID: 40021 RVA: 0x001E8A60 File Offset: 0x001E6E60
	public object[] getArgs()
	{
		return new object[]
		{
			this.mWaitTime,
			this.mPathThorugh,
			this.mSaveBoot,
			this.mPauseBattle,
			this.mTryResumeBattle
		};
	}

	// Token: 0x040055C9 RID: 21961
	public float mWaitTime;

	// Token: 0x040055CA RID: 21962
	public bool mPathThorugh;

	// Token: 0x040055CB RID: 21963
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055CC RID: 21964
	public eNewbieGuideAgrsName mPauseBattle;

	// Token: 0x040055CD RID: 21965
	public eNewbieGuideAgrsName mTryResumeBattle;
}
