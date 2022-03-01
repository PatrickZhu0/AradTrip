using System;

namespace behaviac
{
	// Token: 0x0200309C RID: 12444
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node19 : Action
	{
		// Token: 0x060149FC RID: 84476 RVA: 0x00635A39 File Offset: 0x00633E39
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x060149FD RID: 84477 RVA: 0x00635A4F File Offset: 0x00633E4F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E35A RID: 58202
		private DestinationType method_p0;
	}
}
