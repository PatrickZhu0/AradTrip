using System;

namespace behaviac
{
	// Token: 0x02003511 RID: 13585
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node56 : Action
	{
		// Token: 0x06015265 RID: 86629 RVA: 0x0065F1DA File Offset: 0x0065D5DA
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node56()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521786;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015266 RID: 86630 RVA: 0x0065F211 File Offset: 0x0065D611
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBA5 RID: 60325
		private BE_Target method_p0;

		// Token: 0x0400EBA6 RID: 60326
		private int method_p1;

		// Token: 0x0400EBA7 RID: 60327
		private int method_p2;

		// Token: 0x0400EBA8 RID: 60328
		private int method_p3;

		// Token: 0x0400EBA9 RID: 60329
		private int method_p4;
	}
}
