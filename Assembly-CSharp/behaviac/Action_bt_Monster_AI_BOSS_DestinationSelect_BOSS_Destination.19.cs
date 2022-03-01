using System;

namespace behaviac
{
	// Token: 0x02002FE4 RID: 12260
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node15 : Action
	{
		// Token: 0x06014893 RID: 84115 RVA: 0x0062E781 File Offset: 0x0062CB81
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014894 RID: 84116 RVA: 0x0062E797 File Offset: 0x0062CB97
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1F2 RID: 57842
		private DestinationType method_p0;
	}
}
