using System;

namespace behaviac
{
	// Token: 0x02002FCF RID: 12239
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node19 : Action
	{
		// Token: 0x0601486A RID: 84074 RVA: 0x0062D949 File Offset: 0x0062BD49
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601486B RID: 84075 RVA: 0x0062D95F File Offset: 0x0062BD5F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1C9 RID: 57801
		private DestinationType method_p0;
	}
}
