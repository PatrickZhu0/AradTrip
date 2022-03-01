using System;

namespace behaviac
{
	// Token: 0x020040DF RID: 16607
	public class CompareValue_behaviac_Input : ICompareValue<Input>
	{
		// Token: 0x06016945 RID: 92485 RVA: 0x006D54BC File Offset: 0x006D38BC
		public override bool Equal(Input lhs, Input rhs)
		{
			return lhs.delay == rhs.delay && lhs.skillID == rhs.skillID && lhs.pressTime == rhs.pressTime && lhs.specialChoice == rhs.specialChoice && lhs.randomChangeDirection == rhs.randomChangeDirection && lhs.PKRobotComboCheck == rhs.PKRobotComboCheck && lhs.moveInSkillState == rhs.moveInSkillState && lhs.moveKeepDistance == rhs.moveKeepDistance;
		}

		// Token: 0x06016946 RID: 92486 RVA: 0x006D5561 File Offset: 0x006D3961
		public override bool NotEqual(Input lhs, Input rhs)
		{
			return !this.Equal(lhs, rhs);
		}
	}
}
