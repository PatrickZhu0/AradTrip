using System;

namespace behaviac
{
	// Token: 0x02003D10 RID: 15632
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node2 : Action
	{
		// Token: 0x060161BD RID: 90557 RVA: 0x006AF09E File Offset: 0x006AD49E
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_des_hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060161BE RID: 90558 RVA: 0x006AF0B5 File Offset: 0x006AD4B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA4C RID: 64076
		private DestinationType method_p0;
	}
}
