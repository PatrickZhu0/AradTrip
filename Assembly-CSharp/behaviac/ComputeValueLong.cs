using System;

namespace behaviac
{
	// Token: 0x0200481E RID: 18462
	public class ComputeValueLong : IComputeValue<long>, IComputeValue
	{
		// Token: 0x0601A87B RID: 108667 RVA: 0x00834DAC File Offset: 0x008331AC
		public long Add(long lhs, long rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A87C RID: 108668 RVA: 0x00834DC0 File Offset: 0x008331C0
		public long Sub(long lhs, long rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A87D RID: 108669 RVA: 0x00834DD4 File Offset: 0x008331D4
		public long Mul(long lhs, long rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A87E RID: 108670 RVA: 0x00834DE8 File Offset: 0x008331E8
		public long Div(long lhs, long rhs)
		{
			return lhs / rhs;
		}
	}
}
