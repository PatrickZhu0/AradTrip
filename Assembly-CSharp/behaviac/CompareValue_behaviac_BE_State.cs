using System;

namespace behaviac
{
	// Token: 0x020040DA RID: 16602
	public class CompareValue_behaviac_BE_State : ICompareValue<BE_State>
	{
		// Token: 0x06016922 RID: 92450 RVA: 0x006D53B0 File Offset: 0x006D37B0
		public override bool Equal(BE_State lhs, BE_State rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x06016923 RID: 92451 RVA: 0x006D53B6 File Offset: 0x006D37B6
		public override bool NotEqual(BE_State lhs, BE_State rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016924 RID: 92452 RVA: 0x006D53BF File Offset: 0x006D37BF
		public override bool Greater(BE_State lhs, BE_State rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016925 RID: 92453 RVA: 0x006D53C5 File Offset: 0x006D37C5
		public override bool GreaterEqual(BE_State lhs, BE_State rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x06016926 RID: 92454 RVA: 0x006D53CE File Offset: 0x006D37CE
		public override bool Less(BE_State lhs, BE_State rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016927 RID: 92455 RVA: 0x006D53D4 File Offset: 0x006D37D4
		public override bool LessEqual(BE_State lhs, BE_State rhs)
		{
			return lhs <= rhs;
		}
	}
}
