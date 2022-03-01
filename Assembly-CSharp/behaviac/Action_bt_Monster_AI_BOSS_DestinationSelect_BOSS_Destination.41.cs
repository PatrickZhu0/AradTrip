using System;

namespace behaviac
{
	// Token: 0x02003025 RID: 12325
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node39 : Action
	{
		// Token: 0x06014913 RID: 84243 RVA: 0x00630B09 File Offset: 0x0062EF09
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014914 RID: 84244 RVA: 0x00630B1F File Offset: 0x0062EF1F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E273 RID: 57971
		private DestinationType method_p0;
	}
}
