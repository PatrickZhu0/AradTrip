using System;

namespace behaviac
{
	// Token: 0x0200481F RID: 18463
	public class ComputeValueShort : IComputeValue<short>, IComputeValue
	{
		// Token: 0x0601A880 RID: 108672 RVA: 0x00834E04 File Offset: 0x00833204
		public short Add(short lhs, short rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A881 RID: 108673 RVA: 0x00834E18 File Offset: 0x00833218
		public short Sub(short lhs, short rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A882 RID: 108674 RVA: 0x00834E2C File Offset: 0x0083322C
		public short Mul(short lhs, short rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A883 RID: 108675 RVA: 0x00834E40 File Offset: 0x00833240
		public short Div(short lhs, short rhs)
		{
			return lhs / rhs;
		}
	}
}
