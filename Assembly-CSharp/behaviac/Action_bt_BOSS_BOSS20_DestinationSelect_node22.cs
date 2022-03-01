using System;

namespace behaviac
{
	// Token: 0x02002A03 RID: 10755
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node22 : Action
	{
		// Token: 0x06013D38 RID: 81208 RVA: 0x005EF347 File Offset: 0x005ED747
		public Action_bt_BOSS_BOSS20_DestinationSelect_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06013D39 RID: 81209 RVA: 0x005EF35D File Offset: 0x005ED75D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A7 RID: 55207
		private DestinationType method_p0;
	}
}
