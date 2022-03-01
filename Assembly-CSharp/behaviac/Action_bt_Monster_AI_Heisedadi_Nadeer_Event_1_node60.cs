using System;

namespace behaviac
{
	// Token: 0x0200351A RID: 13594
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node60 : Action
	{
		// Token: 0x06015277 RID: 86647 RVA: 0x0065F555 File Offset: 0x0065D955
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node60()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521774;
		}

		// Token: 0x06015278 RID: 86648 RVA: 0x0065F576 File Offset: 0x0065D976
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBD2 RID: 60370
		private BE_Target method_p0;

		// Token: 0x0400EBD3 RID: 60371
		private int method_p1;
	}
}
