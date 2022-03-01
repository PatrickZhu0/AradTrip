using System;

namespace behaviac
{
	// Token: 0x02002C82 RID: 11394
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node8 : Action
	{
		// Token: 0x060141FC RID: 82428 RVA: 0x0060B48F File Offset: 0x0060988F
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_Destination_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060141FD RID: 82429 RVA: 0x0060B4A5 File Offset: 0x006098A5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBC1 RID: 56257
		private DestinationType method_p0;
	}
}
