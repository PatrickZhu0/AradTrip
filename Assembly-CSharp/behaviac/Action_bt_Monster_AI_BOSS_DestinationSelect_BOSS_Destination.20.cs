using System;

namespace behaviac
{
	// Token: 0x02002FE7 RID: 12263
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node19 : Action
	{
		// Token: 0x06014899 RID: 84121 RVA: 0x0062E86D File Offset: 0x0062CC6D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601489A RID: 84122 RVA: 0x0062E883 File Offset: 0x0062CC83
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1F8 RID: 57848
		private DestinationType method_p0;
	}
}
