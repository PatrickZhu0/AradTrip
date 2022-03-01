using System;

namespace behaviac
{
	// Token: 0x02004811 RID: 18449
	public class CompareValueUInt : ICompareValue<uint>
	{
		// Token: 0x0601A82B RID: 108587 RVA: 0x00834929 File Offset: 0x00832D29
		public override bool Equal(uint lhs, uint rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A82C RID: 108588 RVA: 0x0083492F File Offset: 0x00832D2F
		public override bool NotEqual(uint lhs, uint rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A82D RID: 108589 RVA: 0x00834938 File Offset: 0x00832D38
		public override bool Greater(uint lhs, uint rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A82E RID: 108590 RVA: 0x0083493E File Offset: 0x00832D3E
		public override bool GreaterEqual(uint lhs, uint rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A82F RID: 108591 RVA: 0x00834947 File Offset: 0x00832D47
		public override bool Less(uint lhs, uint rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A830 RID: 108592 RVA: 0x0083494D File Offset: 0x00832D4D
		public override bool LessEqual(uint lhs, uint rhs)
		{
			return lhs <= rhs;
		}
	}
}
