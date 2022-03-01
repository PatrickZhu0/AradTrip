using System;

namespace behaviac
{
	// Token: 0x0200300A RID: 12298
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node35 : Action
	{
		// Token: 0x060148DE RID: 84190 RVA: 0x0062FAF9 File Offset: 0x0062DEF9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x060148DF RID: 84191 RVA: 0x0062FB0F File Offset: 0x0062DF0F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E23E RID: 57918
		private DestinationType method_p0;
	}
}
