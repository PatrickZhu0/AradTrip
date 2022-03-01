using System;

namespace behaviac
{
	// Token: 0x02004817 RID: 18455
	public class CompareValueDouble : ICompareValue<double>
	{
		// Token: 0x0601A855 RID: 108629 RVA: 0x00834A67 File Offset: 0x00832E67
		public override bool Equal(double lhs, double rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A856 RID: 108630 RVA: 0x00834A6D File Offset: 0x00832E6D
		public override bool NotEqual(double lhs, double rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A857 RID: 108631 RVA: 0x00834A76 File Offset: 0x00832E76
		public override bool Greater(double lhs, double rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A858 RID: 108632 RVA: 0x00834A7C File Offset: 0x00832E7C
		public override bool GreaterEqual(double lhs, double rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A859 RID: 108633 RVA: 0x00834A85 File Offset: 0x00832E85
		public override bool Less(double lhs, double rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A85A RID: 108634 RVA: 0x00834A8B File Offset: 0x00832E8B
		public override bool LessEqual(double lhs, double rhs)
		{
			return lhs <= rhs;
		}
	}
}
