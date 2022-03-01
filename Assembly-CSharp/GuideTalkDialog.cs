using System;
using GameClient;

// Token: 0x02001016 RID: 4118
[Serializable]
public class GuideTalkDialog : IUnitData
{
	// Token: 0x06009C4F RID: 40015 RVA: 0x001E8A04 File Offset: 0x001E6E04
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.TALK_DIALOG;
	}

	// Token: 0x06009C50 RID: 40016 RVA: 0x001E8A07 File Offset: 0x001E6E07
	public Type objType()
	{
		return typeof(GuideTalkDialog);
	}

	// Token: 0x06009C51 RID: 40017 RVA: 0x001E8A13 File Offset: 0x001E6E13
	public object[] getArgs()
	{
		return new object[]
		{
			this.id,
			this.mSaveBoot,
			this.mTryPauseBattle
		};
	}

	// Token: 0x040055C6 RID: 21958
	public int id = -1;

	// Token: 0x040055C7 RID: 21959
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055C8 RID: 21960
	public eNewbieGuideAgrsName mTryPauseBattle;
}
