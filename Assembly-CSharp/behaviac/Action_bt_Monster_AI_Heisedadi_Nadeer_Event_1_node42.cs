using System;

namespace behaviac
{
	// Token: 0x02003503 RID: 13571
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node42 : Action
	{
		// Token: 0x06015249 RID: 86601 RVA: 0x0065EDE9 File Offset: 0x0065D1E9
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node42()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521748;
		}

		// Token: 0x0601524A RID: 86602 RVA: 0x0065EE0A File Offset: 0x0065D20A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB82 RID: 60290
		private BE_Target method_p0;

		// Token: 0x0400EB83 RID: 60291
		private int method_p1;
	}
}
