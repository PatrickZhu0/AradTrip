using System;

namespace behaviac
{
	// Token: 0x020040DB RID: 16603
	public class CompareValue_behaviac_BE_Equal : ICompareValue<BE_Equal>
	{
		// Token: 0x06016929 RID: 92457 RVA: 0x006D53E5 File Offset: 0x006D37E5
		public override bool Equal(BE_Equal lhs, BE_Equal rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601692A RID: 92458 RVA: 0x006D53EB File Offset: 0x006D37EB
		public override bool NotEqual(BE_Equal lhs, BE_Equal rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601692B RID: 92459 RVA: 0x006D53F4 File Offset: 0x006D37F4
		public override bool Greater(BE_Equal lhs, BE_Equal rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601692C RID: 92460 RVA: 0x006D53FA File Offset: 0x006D37FA
		public override bool GreaterEqual(BE_Equal lhs, BE_Equal rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601692D RID: 92461 RVA: 0x006D5403 File Offset: 0x006D3803
		public override bool Less(BE_Equal lhs, BE_Equal rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601692E RID: 92462 RVA: 0x006D5409 File Offset: 0x006D3809
		public override bool LessEqual(BE_Equal lhs, BE_Equal rhs)
		{
			return lhs <= rhs;
		}
	}
}
