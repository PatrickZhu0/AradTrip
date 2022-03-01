using System;

namespace behaviac
{
	// Token: 0x02003725 RID: 14117
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3 : Action
	{
		// Token: 0x06015656 RID: 87638 RVA: 0x00674A4A File Offset: 0x00672E4A
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538801;
		}

		// Token: 0x06015657 RID: 87639 RVA: 0x00674A6B File Offset: 0x00672E6B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F026 RID: 61478
		private BE_Target method_p0;

		// Token: 0x0400F027 RID: 61479
		private int method_p1;
	}
}
