using System;

namespace behaviac
{
	// Token: 0x0200480D RID: 18445
	public class CompareValueInt : ICompareValue<int>
	{
		// Token: 0x0601A80F RID: 108559 RVA: 0x00834849 File Offset: 0x00832C49
		public override bool Equal(int lhs, int rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A810 RID: 108560 RVA: 0x0083484F File Offset: 0x00832C4F
		public override bool NotEqual(int lhs, int rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A811 RID: 108561 RVA: 0x00834858 File Offset: 0x00832C58
		public override bool Greater(int lhs, int rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A812 RID: 108562 RVA: 0x0083485E File Offset: 0x00832C5E
		public override bool GreaterEqual(int lhs, int rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A813 RID: 108563 RVA: 0x00834867 File Offset: 0x00832C67
		public override bool Less(int lhs, int rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A814 RID: 108564 RVA: 0x0083486D File Offset: 0x00832C6D
		public override bool LessEqual(int lhs, int rhs)
		{
			return lhs <= rhs;
		}
	}
}
