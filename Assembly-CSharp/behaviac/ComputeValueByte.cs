using System;

namespace behaviac
{
	// Token: 0x02004820 RID: 18464
	public class ComputeValueByte : IComputeValue<sbyte>, IComputeValue
	{
		// Token: 0x0601A885 RID: 108677 RVA: 0x00834E5C File Offset: 0x0083325C
		public sbyte Add(sbyte lhs, sbyte rhs)
		{
			return (sbyte)((int)lhs + (int)rhs);
		}

		// Token: 0x0601A886 RID: 108678 RVA: 0x00834E74 File Offset: 0x00833274
		public sbyte Sub(sbyte lhs, sbyte rhs)
		{
			return (sbyte)((int)lhs - (int)rhs);
		}

		// Token: 0x0601A887 RID: 108679 RVA: 0x00834E8C File Offset: 0x0083328C
		public sbyte Mul(sbyte lhs, sbyte rhs)
		{
			return (sbyte)((int)lhs * (int)rhs);
		}

		// Token: 0x0601A888 RID: 108680 RVA: 0x00834EA4 File Offset: 0x008332A4
		public sbyte Div(sbyte lhs, sbyte rhs)
		{
			return (sbyte)((int)lhs / (int)rhs);
		}
	}
}
