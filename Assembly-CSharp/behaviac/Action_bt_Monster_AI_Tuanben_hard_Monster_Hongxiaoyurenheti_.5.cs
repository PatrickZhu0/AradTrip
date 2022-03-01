using System;

namespace behaviac
{
	// Token: 0x02003D23 RID: 15651
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node6 : Action
	{
		// Token: 0x060161E1 RID: 90593 RVA: 0x006AFAD5 File Offset: 0x006ADED5
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060161E2 RID: 90594 RVA: 0x006AFAEC File Offset: 0x006ADEEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA62 RID: 64098
		private DestinationType method_p0;
	}
}
