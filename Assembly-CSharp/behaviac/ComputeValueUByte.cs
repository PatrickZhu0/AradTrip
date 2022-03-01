using System;

namespace behaviac
{
	// Token: 0x02004824 RID: 18468
	public class ComputeValueUByte : IComputeValue<byte>, IComputeValue
	{
		// Token: 0x0601A899 RID: 108697 RVA: 0x00834FCC File Offset: 0x008333CC
		public byte Add(byte lhs, byte rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A89A RID: 108698 RVA: 0x00834FE0 File Offset: 0x008333E0
		public byte Sub(byte lhs, byte rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A89B RID: 108699 RVA: 0x00834FF4 File Offset: 0x008333F4
		public byte Mul(byte lhs, byte rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A89C RID: 108700 RVA: 0x00835008 File Offset: 0x00833408
		public byte Div(byte lhs, byte rhs)
		{
			return lhs / rhs;
		}
	}
}
