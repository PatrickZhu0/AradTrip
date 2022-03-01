using System;

namespace behaviac
{
	// Token: 0x02003020 RID: 12320
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node31 : Action
	{
		// Token: 0x06014909 RID: 84233 RVA: 0x00630979 File Offset: 0x0062ED79
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601490A RID: 84234 RVA: 0x0063098F File Offset: 0x0062ED8F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E268 RID: 57960
		private DestinationType method_p0;
	}
}
