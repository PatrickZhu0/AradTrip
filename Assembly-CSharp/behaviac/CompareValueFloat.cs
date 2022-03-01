using System;

namespace behaviac
{
	// Token: 0x02004816 RID: 18454
	public class CompareValueFloat : ICompareValue<float>
	{
		// Token: 0x0601A84E RID: 108622 RVA: 0x00834A32 File Offset: 0x00832E32
		public override bool Equal(float lhs, float rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A84F RID: 108623 RVA: 0x00834A38 File Offset: 0x00832E38
		public override bool NotEqual(float lhs, float rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A850 RID: 108624 RVA: 0x00834A41 File Offset: 0x00832E41
		public override bool Greater(float lhs, float rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A851 RID: 108625 RVA: 0x00834A47 File Offset: 0x00832E47
		public override bool GreaterEqual(float lhs, float rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A852 RID: 108626 RVA: 0x00834A50 File Offset: 0x00832E50
		public override bool Less(float lhs, float rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A853 RID: 108627 RVA: 0x00834A56 File Offset: 0x00832E56
		public override bool LessEqual(float lhs, float rhs)
		{
			return lhs <= rhs;
		}
	}
}
