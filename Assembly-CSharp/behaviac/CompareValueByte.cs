using System;

namespace behaviac
{
	// Token: 0x02004810 RID: 18448
	public class CompareValueByte : ICompareValue<sbyte>
	{
		// Token: 0x0601A824 RID: 108580 RVA: 0x008348E8 File Offset: 0x00832CE8
		public override bool Equal(sbyte lhs, sbyte rhs)
		{
			return (int)lhs == (int)rhs;
		}

		// Token: 0x0601A825 RID: 108581 RVA: 0x008348F0 File Offset: 0x00832CF0
		public override bool NotEqual(sbyte lhs, sbyte rhs)
		{
			return (int)lhs != (int)rhs;
		}

		// Token: 0x0601A826 RID: 108582 RVA: 0x008348FB File Offset: 0x00832CFB
		public override bool Greater(sbyte lhs, sbyte rhs)
		{
			return (int)lhs > (int)rhs;
		}

		// Token: 0x0601A827 RID: 108583 RVA: 0x00834903 File Offset: 0x00832D03
		public override bool GreaterEqual(sbyte lhs, sbyte rhs)
		{
			return (int)lhs >= (int)rhs;
		}

		// Token: 0x0601A828 RID: 108584 RVA: 0x0083490E File Offset: 0x00832D0E
		public override bool Less(sbyte lhs, sbyte rhs)
		{
			return (int)lhs < (int)rhs;
		}

		// Token: 0x0601A829 RID: 108585 RVA: 0x00834916 File Offset: 0x00832D16
		public override bool LessEqual(sbyte lhs, sbyte rhs)
		{
			return (int)lhs <= (int)rhs;
		}
	}
}
