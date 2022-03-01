using System;

namespace behaviac
{
	// Token: 0x0200308D RID: 12429
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node35 : Action
	{
		// Token: 0x060149DF RID: 84447 RVA: 0x00634CF1 File Offset: 0x006330F1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060149E0 RID: 84448 RVA: 0x00634D07 File Offset: 0x00633107
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E33D RID: 58173
		private DestinationType method_p0;
	}
}
