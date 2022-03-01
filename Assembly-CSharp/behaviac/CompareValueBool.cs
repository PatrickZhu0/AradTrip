using System;

namespace behaviac
{
	// Token: 0x0200480C RID: 18444
	public class CompareValueBool : ICompareValue<bool>
	{
		// Token: 0x0601A808 RID: 108552 RVA: 0x00834826 File Offset: 0x00832C26
		public override bool Equal(bool lhs, bool rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A809 RID: 108553 RVA: 0x0083482C File Offset: 0x00832C2C
		public override bool NotEqual(bool lhs, bool rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A80A RID: 108554 RVA: 0x00834835 File Offset: 0x00832C35
		public override bool Greater(bool lhs, bool rhs)
		{
			return false;
		}

		// Token: 0x0601A80B RID: 108555 RVA: 0x00834838 File Offset: 0x00832C38
		public override bool GreaterEqual(bool lhs, bool rhs)
		{
			return false;
		}

		// Token: 0x0601A80C RID: 108556 RVA: 0x0083483B File Offset: 0x00832C3B
		public override bool Less(bool lhs, bool rhs)
		{
			return false;
		}

		// Token: 0x0601A80D RID: 108557 RVA: 0x0083483E File Offset: 0x00832C3E
		public override bool LessEqual(bool lhs, bool rhs)
		{
			return false;
		}
	}
}
