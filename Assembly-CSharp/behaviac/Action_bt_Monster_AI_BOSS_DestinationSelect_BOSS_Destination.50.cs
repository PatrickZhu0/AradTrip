using System;

namespace behaviac
{
	// Token: 0x02003040 RID: 12352
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node39 : Action
	{
		// Token: 0x06014948 RID: 84296 RVA: 0x00631C01 File Offset: 0x00630001
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014949 RID: 84297 RVA: 0x00631C17 File Offset: 0x00630017
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2A8 RID: 58024
		private DestinationType method_p0;
	}
}
