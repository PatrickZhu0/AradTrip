using System;

namespace behaviac
{
	// Token: 0x02002A01 RID: 10753
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node18 : Action
	{
		// Token: 0x06013D34 RID: 81204 RVA: 0x005EF2D5 File Offset: 0x005ED6D5
		public Action_bt_BOSS_BOSS20_DestinationSelect_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013D35 RID: 81205 RVA: 0x005EF2EB File Offset: 0x005ED6EB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A5 RID: 55205
		private DestinationType method_p0;
	}
}
