using System;

namespace behaviac
{
	// Token: 0x0200336C RID: 13164
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node22 : Action
	{
		// Token: 0x06014F37 RID: 85815 RVA: 0x0064FB7F File Offset: 0x0064DF7F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06014F38 RID: 85816 RVA: 0x0064FB95 File Offset: 0x0064DF95
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E800 RID: 59392
		private DestinationType method_p0;
	}
}
