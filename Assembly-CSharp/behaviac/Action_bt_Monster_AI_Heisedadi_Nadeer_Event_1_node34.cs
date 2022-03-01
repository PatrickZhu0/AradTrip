using System;

namespace behaviac
{
	// Token: 0x020034F0 RID: 13552
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node34 : Action
	{
		// Token: 0x06015223 RID: 86563 RVA: 0x0065E7AE File Offset: 0x0065CBAE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521797;
		}

		// Token: 0x06015224 RID: 86564 RVA: 0x0065E7CF File Offset: 0x0065CBCF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB44 RID: 60228
		private BE_Target method_p0;

		// Token: 0x0400EB45 RID: 60229
		private int method_p1;
	}
}
