using System;

namespace behaviac
{
	// Token: 0x020040D7 RID: 16599
	public class CompareValue_behaviac_BE_Operation : ICompareValue<BE_Operation>
	{
		// Token: 0x0601690D RID: 92429 RVA: 0x006D5311 File Offset: 0x006D3711
		public override bool Equal(BE_Operation lhs, BE_Operation rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601690E RID: 92430 RVA: 0x006D5317 File Offset: 0x006D3717
		public override bool NotEqual(BE_Operation lhs, BE_Operation rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601690F RID: 92431 RVA: 0x006D5320 File Offset: 0x006D3720
		public override bool Greater(BE_Operation lhs, BE_Operation rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016910 RID: 92432 RVA: 0x006D5326 File Offset: 0x006D3726
		public override bool GreaterEqual(BE_Operation lhs, BE_Operation rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x06016911 RID: 92433 RVA: 0x006D532F File Offset: 0x006D372F
		public override bool Less(BE_Operation lhs, BE_Operation rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016912 RID: 92434 RVA: 0x006D5335 File Offset: 0x006D3735
		public override bool LessEqual(BE_Operation lhs, BE_Operation rhs)
		{
			return lhs <= rhs;
		}
	}
}
