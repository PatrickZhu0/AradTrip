using System;

namespace behaviac
{
	// Token: 0x02001E2F RID: 7727
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_Event_node1 : Action
	{
		// Token: 0x0601260D RID: 75277 RVA: 0x0055E9E9 File Offset: 0x0055CDE9
		public Action_bt_APC_APC_Tiantangmanbuzhe_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601260E RID: 75278 RVA: 0x0055EA1B File Offset: 0x0055CE1B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFF0 RID: 49136
		private BE_Target method_p0;

		// Token: 0x0400BFF1 RID: 49137
		private int method_p1;

		// Token: 0x0400BFF2 RID: 49138
		private int method_p2;

		// Token: 0x0400BFF3 RID: 49139
		private int method_p3;

		// Token: 0x0400BFF4 RID: 49140
		private int method_p4;
	}
}
