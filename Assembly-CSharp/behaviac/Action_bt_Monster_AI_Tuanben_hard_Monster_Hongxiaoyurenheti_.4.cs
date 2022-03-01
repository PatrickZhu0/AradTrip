using System;

namespace behaviac
{
	// Token: 0x02003D22 RID: 15650
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node2 : Action
	{
		// Token: 0x060161DF RID: 90591 RVA: 0x006AFAAA File Offset: 0x006ADEAA
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_des_hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060161E0 RID: 90592 RVA: 0x006AFAC1 File Offset: 0x006ADEC1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA61 RID: 64097
		private DestinationType method_p0;
	}
}
