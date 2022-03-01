using System;

namespace behaviac
{
	// Token: 0x0200481D RID: 18461
	public class ComputeValueInt : IComputeValue<int>, IComputeValue
	{
		// Token: 0x0601A876 RID: 108662 RVA: 0x00834D54 File Offset: 0x00833154
		public int Add(int lhs, int rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A877 RID: 108663 RVA: 0x00834D68 File Offset: 0x00833168
		public int Sub(int lhs, int rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A878 RID: 108664 RVA: 0x00834D7C File Offset: 0x0083317C
		public int Mul(int lhs, int rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A879 RID: 108665 RVA: 0x00834D90 File Offset: 0x00833190
		public int Div(int lhs, int rhs)
		{
			return lhs / rhs;
		}
	}
}
