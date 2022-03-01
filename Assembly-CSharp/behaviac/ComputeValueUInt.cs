using System;

namespace behaviac
{
	// Token: 0x02004821 RID: 18465
	public class ComputeValueUInt : IComputeValue<uint>, IComputeValue
	{
		// Token: 0x0601A88A RID: 108682 RVA: 0x00834EC4 File Offset: 0x008332C4
		public uint Add(uint lhs, uint rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A88B RID: 108683 RVA: 0x00834ED8 File Offset: 0x008332D8
		public uint Sub(uint lhs, uint rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A88C RID: 108684 RVA: 0x00834EEC File Offset: 0x008332EC
		public uint Mul(uint lhs, uint rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A88D RID: 108685 RVA: 0x00834F00 File Offset: 0x00833300
		public uint Div(uint lhs, uint rhs)
		{
			return lhs / rhs;
		}
	}
}
