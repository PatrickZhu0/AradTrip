using System;

namespace behaviac
{
	// Token: 0x02002C83 RID: 11395
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node11 : Action
	{
		// Token: 0x060141FE RID: 82430 RVA: 0x0060B4B9 File Offset: 0x006098B9
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x060141FF RID: 82431 RVA: 0x0060B4CF File Offset: 0x006098CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBC2 RID: 56258
		private DestinationType method_p0;
	}
}
