using System;

namespace behaviac
{
	// Token: 0x02003541 RID: 13633
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node101 : Action
	{
		// Token: 0x060152C5 RID: 86725 RVA: 0x006603A1 File Offset: 0x0065E7A1
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node101()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521774;
		}

		// Token: 0x060152C6 RID: 86726 RVA: 0x006603C2 File Offset: 0x0065E7C2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC7A RID: 60538
		private BE_Target method_p0;

		// Token: 0x0400EC7B RID: 60539
		private int method_p1;
	}
}
