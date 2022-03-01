using System;

namespace behaviac
{
	// Token: 0x02003127 RID: 12583
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node11 : Action
	{
		// Token: 0x06014AF3 RID: 84723 RVA: 0x0063A897 File Offset: 0x00638C97
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
		}

		// Token: 0x06014AF4 RID: 84724 RVA: 0x0063A8B8 File Offset: 0x00638CB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E466 RID: 58470
		private BE_Target method_p0;

		// Token: 0x0400E467 RID: 58471
		private int method_p1;
	}
}
