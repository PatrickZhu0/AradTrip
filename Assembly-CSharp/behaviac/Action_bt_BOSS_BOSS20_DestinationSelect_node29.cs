using System;

namespace behaviac
{
	// Token: 0x02002A07 RID: 10759
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node29 : Action
	{
		// Token: 0x06013D40 RID: 81216 RVA: 0x005EF40B File Offset: 0x005ED80B
		public Action_bt_BOSS_BOSS20_DestinationSelect_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013D41 RID: 81217 RVA: 0x005EF421 File Offset: 0x005ED821
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7AB RID: 55211
		private DestinationType method_p0;
	}
}
