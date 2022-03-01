using System;

namespace behaviac
{
	// Token: 0x02003343 RID: 13123
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node29 : Action
	{
		// Token: 0x06014EEA RID: 85738 RVA: 0x0064E57B File Offset: 0x0064C97B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06014EEB RID: 85739 RVA: 0x0064E591 File Offset: 0x0064C991
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7CD RID: 59341
		private DestinationType method_p0;
	}
}
