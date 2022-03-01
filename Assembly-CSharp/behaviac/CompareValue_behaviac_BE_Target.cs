using System;

namespace behaviac
{
	// Token: 0x020040D5 RID: 16597
	public class CompareValue_behaviac_BE_Target : ICompareValue<BE_Target>
	{
		// Token: 0x060168FF RID: 92415 RVA: 0x006D52A7 File Offset: 0x006D36A7
		public override bool Equal(BE_Target lhs, BE_Target rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x06016900 RID: 92416 RVA: 0x006D52AD File Offset: 0x006D36AD
		public override bool NotEqual(BE_Target lhs, BE_Target rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016901 RID: 92417 RVA: 0x006D52B6 File Offset: 0x006D36B6
		public override bool Greater(BE_Target lhs, BE_Target rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016902 RID: 92418 RVA: 0x006D52BC File Offset: 0x006D36BC
		public override bool GreaterEqual(BE_Target lhs, BE_Target rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x06016903 RID: 92419 RVA: 0x006D52C5 File Offset: 0x006D36C5
		public override bool Less(BE_Target lhs, BE_Target rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016904 RID: 92420 RVA: 0x006D52CB File Offset: 0x006D36CB
		public override bool LessEqual(BE_Target lhs, BE_Target rhs)
		{
			return lhs <= rhs;
		}
	}
}
