using System;

namespace behaviac
{
	// Token: 0x020040DC RID: 16604
	public class CompareValue_behaviac_EventType : ICompareValue<EventType>
	{
		// Token: 0x06016930 RID: 92464 RVA: 0x006D541A File Offset: 0x006D381A
		public override bool Equal(EventType lhs, EventType rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x06016931 RID: 92465 RVA: 0x006D5420 File Offset: 0x006D3820
		public override bool NotEqual(EventType lhs, EventType rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016932 RID: 92466 RVA: 0x006D5429 File Offset: 0x006D3829
		public override bool Greater(EventType lhs, EventType rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016933 RID: 92467 RVA: 0x006D542F File Offset: 0x006D382F
		public override bool GreaterEqual(EventType lhs, EventType rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x06016934 RID: 92468 RVA: 0x006D5438 File Offset: 0x006D3838
		public override bool Less(EventType lhs, EventType rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016935 RID: 92469 RVA: 0x006D543E File Offset: 0x006D383E
		public override bool LessEqual(EventType lhs, EventType rhs)
		{
			return lhs <= rhs;
		}
	}
}
