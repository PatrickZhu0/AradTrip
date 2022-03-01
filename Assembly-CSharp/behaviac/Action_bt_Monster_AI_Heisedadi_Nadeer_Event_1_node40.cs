using System;

namespace behaviac
{
	// Token: 0x02003501 RID: 13569
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node40 : Action
	{
		// Token: 0x06015245 RID: 86597 RVA: 0x0065ED73 File Offset: 0x0065D173
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521746;
		}

		// Token: 0x06015246 RID: 86598 RVA: 0x0065ED94 File Offset: 0x0065D194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB7E RID: 60286
		private BE_Target method_p0;

		// Token: 0x0400EB7F RID: 60287
		private int method_p1;
	}
}
