using System;

namespace behaviac
{
	// Token: 0x02003023 RID: 12323
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node35 : Action
	{
		// Token: 0x0601490F RID: 84239 RVA: 0x00630A65 File Offset: 0x0062EE65
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014910 RID: 84240 RVA: 0x00630A7B File Offset: 0x0062EE7B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E26E RID: 57966
		private DestinationType method_p0;
	}
}
