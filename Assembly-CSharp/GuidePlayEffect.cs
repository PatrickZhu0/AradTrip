using System;
using GameClient;

// Token: 0x02001018 RID: 4120
[Serializable]
public class GuidePlayEffect : IUnitData
{
	// Token: 0x06009C57 RID: 40023 RVA: 0x001E8AC1 File Offset: 0x001E6EC1
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.PLAY_EFFECT;
	}

	// Token: 0x06009C58 RID: 40024 RVA: 0x001E8AC5 File Offset: 0x001E6EC5
	public Type objType()
	{
		return typeof(GuidePlayEffect);
	}

	// Token: 0x06009C59 RID: 40025 RVA: 0x001E8AD1 File Offset: 0x001E6ED1
	public object[] getArgs()
	{
		return new object[]
		{
			this.loadResFile,
			this.mSaveBoot,
			this.mWaitTime
		};
	}

	// Token: 0x040055CE RID: 21966
	public string loadResFile;

	// Token: 0x040055CF RID: 21967
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055D0 RID: 21968
	public float mWaitTime;
}
