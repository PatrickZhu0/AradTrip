using System;

namespace behaviac
{
	// Token: 0x020029FA RID: 10746
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node4 : Action
	{
		// Token: 0x06013D26 RID: 81190 RVA: 0x005EF0D3 File Offset: 0x005ED4D3
		public Action_bt_BOSS_BOSS20_DestinationSelect_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013D27 RID: 81191 RVA: 0x005EF0E9 File Offset: 0x005ED4E9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D798 RID: 55192
		private DestinationType method_p0;
	}
}
