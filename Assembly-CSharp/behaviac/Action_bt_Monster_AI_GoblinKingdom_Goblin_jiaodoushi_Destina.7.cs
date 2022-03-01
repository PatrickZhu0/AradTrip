using System;

namespace behaviac
{
	// Token: 0x02003345 RID: 13125
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node16 : Action
	{
		// Token: 0x06014EEE RID: 85742 RVA: 0x0064E5EB File Offset: 0x0064C9EB
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06014EEF RID: 85743 RVA: 0x0064E601 File Offset: 0x0064CA01
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7CF RID: 59343
		private DestinationType method_p0;
	}
}
