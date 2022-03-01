using System;

namespace behaviac
{
	// Token: 0x0200305F RID: 12383
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node7 : Action
	{
		// Token: 0x06014984 RID: 84356 RVA: 0x006336D9 File Offset: 0x00631AD9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014985 RID: 84357 RVA: 0x006336EF File Offset: 0x00631AEF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2E3 RID: 58083
		private DestinationType method_p0;
	}
}
