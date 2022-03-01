using System;

namespace behaviac
{
	// Token: 0x020040DD RID: 16605
	public class CompareValue_behaviac_LevelCounterType : ICompareValue<LevelCounterType>
	{
		// Token: 0x06016937 RID: 92471 RVA: 0x006D544F File Offset: 0x006D384F
		public override bool Equal(LevelCounterType lhs, LevelCounterType rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x06016938 RID: 92472 RVA: 0x006D5455 File Offset: 0x006D3855
		public override bool NotEqual(LevelCounterType lhs, LevelCounterType rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016939 RID: 92473 RVA: 0x006D545E File Offset: 0x006D385E
		public override bool Greater(LevelCounterType lhs, LevelCounterType rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601693A RID: 92474 RVA: 0x006D5464 File Offset: 0x006D3864
		public override bool GreaterEqual(LevelCounterType lhs, LevelCounterType rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601693B RID: 92475 RVA: 0x006D546D File Offset: 0x006D386D
		public override bool Less(LevelCounterType lhs, LevelCounterType rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601693C RID: 92476 RVA: 0x006D5473 File Offset: 0x006D3873
		public override bool LessEqual(LevelCounterType lhs, LevelCounterType rhs)
		{
			return lhs <= rhs;
		}
	}
}
