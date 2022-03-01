using System;
using GameClient;

// Token: 0x02001013 RID: 4115
[Serializable]
public class GuideNewIconUnlock : IUnitData
{
	// Token: 0x06009C43 RID: 40003 RVA: 0x001E8873 File Offset: 0x001E6C73
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.NEWICON_UNLOCK;
	}

	// Token: 0x06009C44 RID: 40004 RVA: 0x001E8877 File Offset: 0x001E6C77
	public Type objType()
	{
		return typeof(GuideNewIconUnlock);
	}

	// Token: 0x06009C45 RID: 40005 RVA: 0x001E8884 File Offset: 0x001E6C84
	public object[] getArgs()
	{
		return new object[]
		{
			this.loadResFile,
			this.TargetObjPath,
			this.iconPath,
			this.iconName,
			this.waittime,
			this.mSaveBoot,
			this.mTryPauseBattle
		};
	}

	// Token: 0x040055B0 RID: 21936
	public string loadResFile;

	// Token: 0x040055B1 RID: 21937
	public string TargetObjPath;

	// Token: 0x040055B2 RID: 21938
	public string iconPath;

	// Token: 0x040055B3 RID: 21939
	public string iconName;

	// Token: 0x040055B4 RID: 21940
	public float waittime;

	// Token: 0x040055B5 RID: 21941
	public eNewbieGuideAgrsName mSaveBoot;

	// Token: 0x040055B6 RID: 21942
	public eNewbieGuideAgrsName mTryPauseBattle;
}
