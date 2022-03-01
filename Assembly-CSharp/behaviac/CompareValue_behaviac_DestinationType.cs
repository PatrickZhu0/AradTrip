using System;

namespace behaviac
{
	// Token: 0x020040D6 RID: 16598
	public class CompareValue_behaviac_DestinationType : ICompareValue<DestinationType>
	{
		// Token: 0x06016906 RID: 92422 RVA: 0x006D52DC File Offset: 0x006D36DC
		public override bool Equal(DestinationType lhs, DestinationType rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x06016907 RID: 92423 RVA: 0x006D52E2 File Offset: 0x006D36E2
		public override bool NotEqual(DestinationType lhs, DestinationType rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016908 RID: 92424 RVA: 0x006D52EB File Offset: 0x006D36EB
		public override bool Greater(DestinationType lhs, DestinationType rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016909 RID: 92425 RVA: 0x006D52F1 File Offset: 0x006D36F1
		public override bool GreaterEqual(DestinationType lhs, DestinationType rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601690A RID: 92426 RVA: 0x006D52FA File Offset: 0x006D36FA
		public override bool Less(DestinationType lhs, DestinationType rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601690B RID: 92427 RVA: 0x006D5300 File Offset: 0x006D3700
		public override bool LessEqual(DestinationType lhs, DestinationType rhs)
		{
			return lhs <= rhs;
		}
	}
}
