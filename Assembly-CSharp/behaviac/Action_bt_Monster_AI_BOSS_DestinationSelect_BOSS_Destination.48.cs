using System;

namespace behaviac
{
	// Token: 0x0200303B RID: 12347
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node31 : Action
	{
		// Token: 0x0601493E RID: 84286 RVA: 0x00631A71 File Offset: 0x0062FE71
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_4_0dumaowang_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601493F RID: 84287 RVA: 0x00631A87 File Offset: 0x0062FE87
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E29D RID: 58013
		private DestinationType method_p0;
	}
}
