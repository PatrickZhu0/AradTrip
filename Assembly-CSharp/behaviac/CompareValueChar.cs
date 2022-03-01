using System;

namespace behaviac
{
	// Token: 0x02004815 RID: 18453
	public class CompareValueChar : ICompareValue<char>
	{
		// Token: 0x0601A847 RID: 108615 RVA: 0x008349FD File Offset: 0x00832DFD
		public override bool Equal(char lhs, char rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A848 RID: 108616 RVA: 0x00834A03 File Offset: 0x00832E03
		public override bool NotEqual(char lhs, char rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A849 RID: 108617 RVA: 0x00834A0C File Offset: 0x00832E0C
		public override bool Greater(char lhs, char rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x0601A84A RID: 108618 RVA: 0x00834A12 File Offset: 0x00832E12
		public override bool GreaterEqual(char lhs, char rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x0601A84B RID: 108619 RVA: 0x00834A1B File Offset: 0x00832E1B
		public override bool Less(char lhs, char rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x0601A84C RID: 108620 RVA: 0x00834A21 File Offset: 0x00832E21
		public override bool LessEqual(char lhs, char rhs)
		{
			return lhs <= rhs;
		}
	}
}
