using System;

namespace behaviac
{
	// Token: 0x02003534 RID: 13620
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node80 : Action
	{
		// Token: 0x060152AB RID: 86699 RVA: 0x0065FEDD File Offset: 0x0065E2DD
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node80()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521774;
		}

		// Token: 0x060152AC RID: 86700 RVA: 0x0065FEFE File Offset: 0x0065E2FE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC42 RID: 60482
		private BE_Target method_p0;

		// Token: 0x0400EC43 RID: 60483
		private int method_p1;
	}
}
