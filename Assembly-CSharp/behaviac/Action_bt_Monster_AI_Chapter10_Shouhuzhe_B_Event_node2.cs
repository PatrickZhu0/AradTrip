using System;

namespace behaviac
{
	// Token: 0x02003138 RID: 12600
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node2 : Action
	{
		// Token: 0x06014B13 RID: 84755 RVA: 0x0063B3F4 File Offset: 0x006397F4
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522054;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014B14 RID: 84756 RVA: 0x0063B42B File Offset: 0x0063982B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E484 RID: 58500
		private BE_Target method_p0;

		// Token: 0x0400E485 RID: 58501
		private int method_p1;

		// Token: 0x0400E486 RID: 58502
		private int method_p2;

		// Token: 0x0400E487 RID: 58503
		private int method_p3;

		// Token: 0x0400E488 RID: 58504
		private int method_p4;
	}
}
