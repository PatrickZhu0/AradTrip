using System;

namespace behaviac
{
	// Token: 0x02003029 RID: 12329
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node7 : Action
	{
		// Token: 0x0601491A RID: 84250 RVA: 0x006314E9 File Offset: 0x0062F8E9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601491B RID: 84251 RVA: 0x006314FF File Offset: 0x0062F8FF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E279 RID: 57977
		private DestinationType method_p0;
	}
}
