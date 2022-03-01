using System;

namespace behaviac
{
	// Token: 0x0200337E RID: 13182
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21 : Action
	{
		// Token: 0x06014F59 RID: 85849 RVA: 0x006508E6 File Offset: 0x0064ECE6
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521399;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F5A RID: 85850 RVA: 0x0065091E File Offset: 0x0064ED1E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E821 RID: 59425
		private BE_Target method_p0;

		// Token: 0x0400E822 RID: 59426
		private int method_p1;

		// Token: 0x0400E823 RID: 59427
		private int method_p2;

		// Token: 0x0400E824 RID: 59428
		private int method_p3;

		// Token: 0x0400E825 RID: 59429
		private int method_p4;
	}
}
