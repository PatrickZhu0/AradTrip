using System;

namespace behaviac
{
	// Token: 0x0200333C RID: 13116
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node13 : Action
	{
		// Token: 0x06014EDC RID: 85724 RVA: 0x0064E3AF File Offset: 0x0064C7AF
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014EDD RID: 85725 RVA: 0x0064E3C5 File Offset: 0x0064C7C5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C3 RID: 59331
		private DestinationType method_p0;
	}
}
