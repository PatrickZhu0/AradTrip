using System;

namespace behaviac
{
	// Token: 0x02004812 RID: 18450
	public class CompareValueULong : ICompareValue<ulong>
	{
		// Token: 0x0601A832 RID: 108594 RVA: 0x0083495E File Offset: 0x00832D5E
		public override bool Equal(ulong lhs, ulong rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A833 RID: 108595 RVA: 0x00834964 File Offset: 0x00832D64
		public override bool NotEqual(ulong lhs, ulong rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A834 RID: 108596 RVA: 0x0083496D File Offset: 0x00832D6D
		public override bool Greater(ulong lhs, ulong rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A835 RID: 108597 RVA: 0x00834973 File Offset: 0x00832D73
		public override bool GreaterEqual(ulong lhs, ulong rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A836 RID: 108598 RVA: 0x0083497C File Offset: 0x00832D7C
		public override bool Less(ulong lhs, ulong rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A837 RID: 108599 RVA: 0x00834982 File Offset: 0x00832D82
		public override bool LessEqual(ulong lhs, ulong rhs)
		{
			return lhs <= rhs;
		}
	}
}
