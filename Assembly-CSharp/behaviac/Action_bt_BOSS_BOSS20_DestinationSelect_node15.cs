using System;

namespace behaviac
{
	// Token: 0x02002A00 RID: 10752
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node15 : Action
	{
		// Token: 0x06013D32 RID: 81202 RVA: 0x005EF2AB File Offset: 0x005ED6AB
		public Action_bt_BOSS_BOSS20_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013D33 RID: 81203 RVA: 0x005EF2C1 File Offset: 0x005ED6C1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A4 RID: 55204
		private DestinationType method_p0;
	}
}
