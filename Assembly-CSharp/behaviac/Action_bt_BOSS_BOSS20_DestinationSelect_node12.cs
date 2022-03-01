using System;

namespace behaviac
{
	// Token: 0x020029FE RID: 10750
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_DestinationSelect_node12 : Action
	{
		// Token: 0x06013D2E RID: 81198 RVA: 0x005EF23B File Offset: 0x005ED63B
		public Action_bt_BOSS_BOSS20_DestinationSelect_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06013D2F RID: 81199 RVA: 0x005EF251 File Offset: 0x005ED651
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7A2 RID: 55202
		private DestinationType method_p0;
	}
}
