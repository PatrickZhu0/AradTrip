using System;

namespace behaviac
{
	// Token: 0x020040D8 RID: 16600
	public class CompareValue_behaviac_HMType : ICompareValue<HMType>
	{
		// Token: 0x06016914 RID: 92436 RVA: 0x006D5346 File Offset: 0x006D3746
		public override bool Equal(HMType lhs, HMType rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x06016915 RID: 92437 RVA: 0x006D534C File Offset: 0x006D374C
		public override bool NotEqual(HMType lhs, HMType rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016916 RID: 92438 RVA: 0x006D5355 File Offset: 0x006D3755
		public override bool Greater(HMType lhs, HMType rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016917 RID: 92439 RVA: 0x006D535B File Offset: 0x006D375B
		public override bool GreaterEqual(HMType lhs, HMType rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x06016918 RID: 92440 RVA: 0x006D5364 File Offset: 0x006D3764
		public override bool Less(HMType lhs, HMType rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016919 RID: 92441 RVA: 0x006D536A File Offset: 0x006D376A
		public override bool LessEqual(HMType lhs, HMType rhs)
		{
			return lhs <= rhs;
		}
	}
}
