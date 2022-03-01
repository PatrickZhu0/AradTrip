using System;

namespace behaviac
{
	// Token: 0x02004822 RID: 18466
	public class ComputeValueULong : IComputeValue<ulong>, IComputeValue
	{
		// Token: 0x0601A88F RID: 108687 RVA: 0x00834F1C File Offset: 0x0083331C
		public ulong Add(ulong lhs, ulong rhs)
		{
			return lhs + rhs;
		}

		// Token: 0x0601A890 RID: 108688 RVA: 0x00834F30 File Offset: 0x00833330
		public ulong Sub(ulong lhs, ulong rhs)
		{
			return lhs - rhs;
		}

		// Token: 0x0601A891 RID: 108689 RVA: 0x00834F44 File Offset: 0x00833344
		public ulong Mul(ulong lhs, ulong rhs)
		{
			return lhs * rhs;
		}

		// Token: 0x0601A892 RID: 108690 RVA: 0x00834F58 File Offset: 0x00833358
		public ulong Div(ulong lhs, ulong rhs)
		{
			return lhs / rhs;
		}
	}
}
