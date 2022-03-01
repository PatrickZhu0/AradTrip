using System;

// Token: 0x0200100E RID: 4110
[Serializable]
public class GuideCover : IUnitData
{
	// Token: 0x06009C2F RID: 39983 RVA: 0x001E86C2 File Offset: 0x001E6AC2
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.COVER;
	}

	// Token: 0x06009C30 RID: 39984 RVA: 0x001E86C6 File Offset: 0x001E6AC6
	public Type objType()
	{
		return typeof(GuideCover);
	}

	// Token: 0x06009C31 RID: 39985 RVA: 0x001E86D2 File Offset: 0x001E6AD2
	public object[] getArgs()
	{
		return new object[]
		{
			this.mFrameType
		};
	}

	// Token: 0x0400559B RID: 21915
	public string mFrameType;
}
