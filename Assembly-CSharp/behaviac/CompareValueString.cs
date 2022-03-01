using System;

namespace behaviac
{
	// Token: 0x02004818 RID: 18456
	public class CompareValueString : ICompareValue<string>
	{
		// Token: 0x0601A85C RID: 108636 RVA: 0x00834A9C File Offset: 0x00832E9C
		public override bool Equal(string lhs, string rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A85D RID: 108637 RVA: 0x00834AA5 File Offset: 0x00832EA5
		public override bool NotEqual(string lhs, string rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A85E RID: 108638 RVA: 0x00834AAE File Offset: 0x00832EAE
		public override bool Greater(string lhs, string rhs)
		{
			return false;
		}

		// Token: 0x0601A85F RID: 108639 RVA: 0x00834AB1 File Offset: 0x00832EB1
		public override bool GreaterEqual(string lhs, string rhs)
		{
			return false;
		}

		// Token: 0x0601A860 RID: 108640 RVA: 0x00834AB4 File Offset: 0x00832EB4
		public override bool Less(string lhs, string rhs)
		{
			return false;
		}

		// Token: 0x0601A861 RID: 108641 RVA: 0x00834AB7 File Offset: 0x00832EB7
		public override bool LessEqual(string lhs, string rhs)
		{
			return false;
		}
	}
}
