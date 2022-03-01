using System;

namespace behaviac
{
	// Token: 0x02003D11 RID: 15633
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node6 : Action
	{
		// Token: 0x060161BF RID: 90559 RVA: 0x006AF0C9 File Offset: 0x006AD4C9
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060161C0 RID: 90560 RVA: 0x006AF0E0 File Offset: 0x006AD4E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA4D RID: 64077
		private DestinationType method_p0;
	}
}
