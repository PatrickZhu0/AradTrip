using System;

namespace behaviac
{
	// Token: 0x02003393 RID: 13203
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node33 : Action
	{
		// Token: 0x06014F83 RID: 85891 RVA: 0x00651022 File Offset: 0x0064F422
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521403;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F84 RID: 85892 RVA: 0x0065105A File Offset: 0x0064F45A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E85E RID: 59486
		private BE_Target method_p0;

		// Token: 0x0400E85F RID: 59487
		private int method_p1;

		// Token: 0x0400E860 RID: 59488
		private int method_p2;

		// Token: 0x0400E861 RID: 59489
		private int method_p3;

		// Token: 0x0400E862 RID: 59490
		private int method_p4;
	}
}
