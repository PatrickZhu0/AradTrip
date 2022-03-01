using System;

namespace behaviac
{
	// Token: 0x020034EA RID: 13546
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node3 : Action
	{
		// Token: 0x06015217 RID: 86551 RVA: 0x0065E5AE File Offset: 0x0065C9AE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521799;
		}

		// Token: 0x06015218 RID: 86552 RVA: 0x0065E5CF File Offset: 0x0065C9CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB30 RID: 60208
		private BE_Target method_p0;

		// Token: 0x0400EB31 RID: 60209
		private int method_p1;
	}
}
