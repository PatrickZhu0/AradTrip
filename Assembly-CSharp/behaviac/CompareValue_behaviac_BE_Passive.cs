using System;

namespace behaviac
{
	// Token: 0x020040D9 RID: 16601
	public class CompareValue_behaviac_BE_Passive : ICompareValue<BE_Passive>
	{
		// Token: 0x0601691B RID: 92443 RVA: 0x006D537B File Offset: 0x006D377B
		public override bool Equal(BE_Passive lhs, BE_Passive rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601691C RID: 92444 RVA: 0x006D5381 File Offset: 0x006D3781
		public override bool NotEqual(BE_Passive lhs, BE_Passive rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601691D RID: 92445 RVA: 0x006D538A File Offset: 0x006D378A
		public override bool Greater(BE_Passive lhs, BE_Passive rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601691E RID: 92446 RVA: 0x006D5390 File Offset: 0x006D3790
		public override bool GreaterEqual(BE_Passive lhs, BE_Passive rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601691F RID: 92447 RVA: 0x006D5399 File Offset: 0x006D3799
		public override bool Less(BE_Passive lhs, BE_Passive rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016920 RID: 92448 RVA: 0x006D539F File Offset: 0x006D379F
		public override bool LessEqual(BE_Passive lhs, BE_Passive rhs)
		{
			return lhs <= rhs;
		}
	}
}
