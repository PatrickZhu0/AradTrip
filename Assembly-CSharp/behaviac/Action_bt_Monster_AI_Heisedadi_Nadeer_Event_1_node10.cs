using System;

namespace behaviac
{
	// Token: 0x020034EF RID: 13551
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node10 : Action
	{
		// Token: 0x06015221 RID: 86561 RVA: 0x0065E773 File Offset: 0x0065CB73
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521796;
		}

		// Token: 0x06015222 RID: 86562 RVA: 0x0065E794 File Offset: 0x0065CB94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB42 RID: 60226
		private BE_Target method_p0;

		// Token: 0x0400EB43 RID: 60227
		private int method_p1;
	}
}
