using System;

namespace behaviac
{
	// Token: 0x02003093 RID: 12435
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node7 : Action
	{
		// Token: 0x060149EA RID: 84458 RVA: 0x00635775 File Offset: 0x00633B75
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x060149EB RID: 84459 RVA: 0x0063578B File Offset: 0x00633B8B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E348 RID: 58184
		private DestinationType method_p0;
	}
}
