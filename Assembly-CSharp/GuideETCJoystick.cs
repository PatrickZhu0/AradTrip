using System;

// Token: 0x02001010 RID: 4112
[Serializable]
public class GuideETCJoystick : IUnitData
{
	// Token: 0x06009C37 RID: 39991 RVA: 0x001E872A File Offset: 0x001E6B2A
	public NewbieGuideComType getType()
	{
		return NewbieGuideComType.ETC_JOYSTICK;
	}

	// Token: 0x06009C38 RID: 39992 RVA: 0x001E872D File Offset: 0x001E6B2D
	public Type objType()
	{
		return typeof(GuideETCJoystick);
	}

	// Token: 0x06009C39 RID: 39993 RVA: 0x001E8739 File Offset: 0x001E6B39
	public object[] getArgs()
	{
		return new object[]
		{
			this.mPosX
		};
	}

	// Token: 0x0400559F RID: 21919
	public float mPosX;
}
