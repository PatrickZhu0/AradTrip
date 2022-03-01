using System;

namespace behaviac
{
	// Token: 0x02003508 RID: 13576
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node49 : Action
	{
		// Token: 0x06015253 RID: 86611 RVA: 0x0065EF35 File Offset: 0x0065D335
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node49()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521748;
		}

		// Token: 0x06015254 RID: 86612 RVA: 0x0065EF56 File Offset: 0x0065D356
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB8D RID: 60301
		private BE_Target method_p0;

		// Token: 0x0400EB8E RID: 60302
		private int method_p1;
	}
}
