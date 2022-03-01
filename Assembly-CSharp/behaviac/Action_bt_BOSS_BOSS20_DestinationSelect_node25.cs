using System;

namespace behaviac
{
	// Token: 0x02002A05 RID: 10757
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node25 : Action
	{
		// Token: 0x06013D3C RID: 81212 RVA: 0x005EF3B7 File Offset: 0x005ED7B7
		public Action_bt_BOSS_BOSS20_DestinationSelect_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013D3D RID: 81213 RVA: 0x005EF3CD File Offset: 0x005ED7CD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A9 RID: 55209
		private DestinationType method_p0;
	}
}
