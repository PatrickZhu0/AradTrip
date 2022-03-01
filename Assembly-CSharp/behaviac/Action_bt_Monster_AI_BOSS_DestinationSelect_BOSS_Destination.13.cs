using System;

namespace behaviac
{
	// Token: 0x02002FD2 RID: 12242
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node23 : Action
	{
		// Token: 0x06014870 RID: 84080 RVA: 0x0062DA35 File Offset: 0x0062BE35
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06014871 RID: 84081 RVA: 0x0062DA4B File Offset: 0x0062BE4B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1CF RID: 57807
		private DestinationType method_p0;
	}
}
