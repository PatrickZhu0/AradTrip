using System;

namespace behaviac
{
	// Token: 0x02002A06 RID: 10758
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node28 : Action
	{
		// Token: 0x06013D3E RID: 81214 RVA: 0x005EF3E1 File Offset: 0x005ED7E1
		public Action_bt_BOSS_BOSS20_DestinationSelect_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013D3F RID: 81215 RVA: 0x005EF3F7 File Offset: 0x005ED7F7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7AA RID: 55210
		private DestinationType method_p0;
	}
}
