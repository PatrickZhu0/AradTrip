using System;

namespace behaviac
{
	// Token: 0x02003502 RID: 13570
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node41 : Action
	{
		// Token: 0x06015247 RID: 86599 RVA: 0x0065EDAE File Offset: 0x0065D1AE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521747;
		}

		// Token: 0x06015248 RID: 86600 RVA: 0x0065EDCF File Offset: 0x0065D1CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB80 RID: 60288
		private BE_Target method_p0;

		// Token: 0x0400EB81 RID: 60289
		private int method_p1;
	}
}
