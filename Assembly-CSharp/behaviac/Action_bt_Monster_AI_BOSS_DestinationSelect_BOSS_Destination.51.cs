using System;

namespace behaviac
{
	// Token: 0x02003044 RID: 12356
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node7 : Action
	{
		// Token: 0x0601494F RID: 84303 RVA: 0x006325E1 File Offset: 0x006309E1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014950 RID: 84304 RVA: 0x006325F7 File Offset: 0x006309F7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2AE RID: 58030
		private DestinationType method_p0;
	}
}
