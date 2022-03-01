using System;

namespace behaviac
{
	// Token: 0x02002FC0 RID: 12224
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node31 : Action
	{
		// Token: 0x0601484D RID: 84045 RVA: 0x0062CCE9 File Offset: 0x0062B0E9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601484E RID: 84046 RVA: 0x0062CCFF File Offset: 0x0062B0FF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1AC RID: 57772
		private DestinationType method_p0;
	}
}
