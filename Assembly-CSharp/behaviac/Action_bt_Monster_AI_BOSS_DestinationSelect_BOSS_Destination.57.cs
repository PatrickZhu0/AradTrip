using System;

namespace behaviac
{
	// Token: 0x02003056 RID: 12374
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node31 : Action
	{
		// Token: 0x06014973 RID: 84339 RVA: 0x00632B69 File Offset: 0x00630F69
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014974 RID: 84340 RVA: 0x00632B7F File Offset: 0x00630F7F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2D2 RID: 58066
		private DestinationType method_p0;
	}
}
