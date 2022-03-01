using System;

namespace behaviac
{
	// Token: 0x02003071 RID: 12401
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node31 : Action
	{
		// Token: 0x060149A8 RID: 84392 RVA: 0x00633C61 File Offset: 0x00632061
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060149A9 RID: 84393 RVA: 0x00633C77 File Offset: 0x00632077
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E307 RID: 58119
		private DestinationType method_p0;
	}
}
