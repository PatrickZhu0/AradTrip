using System;

namespace behaviac
{
	// Token: 0x0200480E RID: 18446
	public class CompareValueLong : ICompareValue<long>
	{
		// Token: 0x0601A816 RID: 108566 RVA: 0x0083487E File Offset: 0x00832C7E
		public override bool Equal(long lhs, long rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A817 RID: 108567 RVA: 0x00834884 File Offset: 0x00832C84
		public override bool NotEqual(long lhs, long rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A818 RID: 108568 RVA: 0x0083488D File Offset: 0x00832C8D
		public override bool Greater(long lhs, long rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A819 RID: 108569 RVA: 0x00834893 File Offset: 0x00832C93
		public override bool GreaterEqual(long lhs, long rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A81A RID: 108570 RVA: 0x0083489C File Offset: 0x00832C9C
		public override bool Less(long lhs, long rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A81B RID: 108571 RVA: 0x008348A2 File Offset: 0x00832CA2
		public override bool LessEqual(long lhs, long rhs)
		{
			return lhs <= rhs;
		}
	}
}
