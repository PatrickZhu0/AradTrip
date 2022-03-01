using System;

namespace behaviac
{
	// Token: 0x02002FC9 RID: 12233
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node11 : Action
	{
		// Token: 0x0601485E RID: 84062 RVA: 0x0062D771 File Offset: 0x0062BB71
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601485F RID: 84063 RVA: 0x0062D787 File Offset: 0x0062BB87
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1BD RID: 57789
		private DestinationType method_p0;
	}
}
