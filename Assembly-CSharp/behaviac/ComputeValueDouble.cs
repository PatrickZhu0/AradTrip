using System;

namespace behaviac
{
	// Token: 0x02004826 RID: 18470
	public class ComputeValueDouble : IComputeValue<double>, IComputeValue
	{
		// Token: 0x0601A8A3 RID: 108707 RVA: 0x0083507C File Offset: 0x0083347C
		public double Add(double lhs, double rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A8A4 RID: 108708 RVA: 0x00835090 File Offset: 0x00833490
		public double Sub(double lhs, double rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A8A5 RID: 108709 RVA: 0x008350A4 File Offset: 0x008334A4
		public double Mul(double lhs, double rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A8A6 RID: 108710 RVA: 0x008350B8 File Offset: 0x008334B8
		public double Div(double lhs, double rhs)
		{
			return lhs / rhs;
		}
	}
}
