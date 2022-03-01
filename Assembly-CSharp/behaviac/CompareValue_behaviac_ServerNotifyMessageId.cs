using System;

namespace behaviac
{
	// Token: 0x020040DE RID: 16606
	public class CompareValue_behaviac_ServerNotifyMessageId : ICompareValue<ServerNotifyMessageId>
	{
		// Token: 0x0601693E RID: 92478 RVA: 0x006D5484 File Offset: 0x006D3884
		public override bool Equal(ServerNotifyMessageId lhs, ServerNotifyMessageId rhs)
		{
			return lhs == rhs;
		}

		// Token: 0x0601693F RID: 92479 RVA: 0x006D548A File Offset: 0x006D388A
		public override bool NotEqual(ServerNotifyMessageId lhs, ServerNotifyMessageId rhs)
		{
			return lhs != rhs;
		}

		// Token: 0x06016940 RID: 92480 RVA: 0x006D5493 File Offset: 0x006D3893
		public override bool Greater(ServerNotifyMessageId lhs, ServerNotifyMessageId rhs)
		{
			return lhs > rhs;
		}

		// Token: 0x06016941 RID: 92481 RVA: 0x006D5499 File Offset: 0x006D3899
		public override bool GreaterEqual(ServerNotifyMessageId lhs, ServerNotifyMessageId rhs)
		{
			return lhs >= rhs;
		}

		// Token: 0x06016942 RID: 92482 RVA: 0x006D54A2 File Offset: 0x006D38A2
		public override bool Less(ServerNotifyMessageId lhs, ServerNotifyMessageId rhs)
		{
			return lhs < rhs;
		}

		// Token: 0x06016943 RID: 92483 RVA: 0x006D54A8 File Offset: 0x006D38A8
		public override bool LessEqual(ServerNotifyMessageId lhs, ServerNotifyMessageId rhs)
		{
			return lhs <= rhs;
		}
	}
}
