using System;

namespace behaviac
{
	// Token: 0x02004823 RID: 18467
	public class ComputeValueUShort : IComputeValue<ushort>, IComputeValue
	{
		// Token: 0x0601A894 RID: 108692 RVA: 0x00834F74 File Offset: 0x00833374
		public ushort Add(ushort lhs, ushort rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A895 RID: 108693 RVA: 0x00834F88 File Offset: 0x00833388
		public ushort Sub(ushort lhs, ushort rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A896 RID: 108694 RVA: 0x00834F9C File Offset: 0x0083339C
		public ushort Mul(ushort lhs, ushort rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A897 RID: 108695 RVA: 0x00834FB0 File Offset: 0x008333B0
		public ushort Div(ushort lhs, ushort rhs)
		{
			return lhs / rhs;
		}
	}
}
