using System;

namespace behaviac
{
	// Token: 0x0200480F RID: 18447
	public class CompareValueShort : ICompareValue<short>
	{
		// Token: 0x0601A81D RID: 108573 RVA: 0x008348B3 File Offset: 0x00832CB3
		public override bool Equal(short lhs, short rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A81E RID: 108574 RVA: 0x008348B9 File Offset: 0x00832CB9
		public override bool NotEqual(short lhs, short rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A81F RID: 108575 RVA: 0x008348C2 File Offset: 0x00832CC2
		public override bool Greater(short lhs, short rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A820 RID: 108576 RVA: 0x008348C8 File Offset: 0x00832CC8
		public override bool GreaterEqual(short lhs, short rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A821 RID: 108577 RVA: 0x008348D1 File Offset: 0x00832CD1
		public override bool Less(short lhs, short rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A822 RID: 108578 RVA: 0x008348D7 File Offset: 0x00832CD7
		public override bool LessEqual(short lhs, short rhs)
		{
			return lhs <= rhs;
		}
	}
}
