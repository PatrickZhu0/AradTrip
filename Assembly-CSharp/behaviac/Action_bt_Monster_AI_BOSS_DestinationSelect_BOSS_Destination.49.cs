using System;

namespace behaviac
{
	// Token: 0x0200303E RID: 12350
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node35 : Action
	{
		// Token: 0x06014944 RID: 84292 RVA: 0x00631B5D File Offset: 0x0062FF5D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014945 RID: 84293 RVA: 0x00631B73 File Offset: 0x0062FF73
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2A3 RID: 58019
		private DestinationType method_p0;
	}
}
