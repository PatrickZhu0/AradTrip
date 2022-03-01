using System;

namespace behaviac
{
	// Token: 0x02003068 RID: 12392
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node19 : Action
	{
		// Token: 0x06014996 RID: 84374 RVA: 0x0063399D File Offset: 0x00631D9D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014997 RID: 84375 RVA: 0x006339B3 File Offset: 0x00631DB3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2F5 RID: 58101
		private DestinationType method_p0;
	}
}
