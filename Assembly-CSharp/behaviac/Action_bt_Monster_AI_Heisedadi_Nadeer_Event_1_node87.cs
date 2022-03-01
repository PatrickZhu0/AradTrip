using System;

namespace behaviac
{
	// Token: 0x02003523 RID: 13603
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node87 : Action
	{
		// Token: 0x06015289 RID: 86665 RVA: 0x0065F88D File Offset: 0x0065DC8D
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node87()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521773;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601528A RID: 86666 RVA: 0x0065F8C4 File Offset: 0x0065DCC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBF6 RID: 60406
		private BE_Target method_p0;

		// Token: 0x0400EBF7 RID: 60407
		private int method_p1;

		// Token: 0x0400EBF8 RID: 60408
		private int method_p2;

		// Token: 0x0400EBF9 RID: 60409
		private int method_p3;

		// Token: 0x0400EBFA RID: 60410
		private int method_p4;
	}
}
