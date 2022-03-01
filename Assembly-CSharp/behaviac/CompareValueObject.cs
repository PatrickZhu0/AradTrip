using System;

namespace behaviac
{
	// Token: 0x02004819 RID: 18457
	public class CompareValueObject : ICompareValue<object>
	{
		// Token: 0x0601A863 RID: 108643 RVA: 0x00834AC2 File Offset: 0x00832EC2
		public override bool Equal(object lhs, object rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601A864 RID: 108644 RVA: 0x00834AC8 File Offset: 0x00832EC8
		public override bool NotEqual(object lhs, object rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x0601A865 RID: 108645 RVA: 0x00834AD1 File Offset: 0x00832ED1
		public override bool Greater(object lhs, object rhs)
		{
			return false;
		}

		// Token: 0x0601A866 RID: 108646 RVA: 0x00834AD4 File Offset: 0x00832ED4
		public override bool GreaterEqual(object lhs, object rhs)
		{
			return false;
		}

		// Token: 0x0601A867 RID: 108647 RVA: 0x00834AD7 File Offset: 0x00832ED7
		public override bool Less(object lhs, object rhs)
		{
			return false;
		}

		// Token: 0x0601A868 RID: 108648 RVA: 0x00834ADA File Offset: 0x00832EDA
		public override bool LessEqual(object lhs, object rhs)
		{
			return false;
		}
	}
}
