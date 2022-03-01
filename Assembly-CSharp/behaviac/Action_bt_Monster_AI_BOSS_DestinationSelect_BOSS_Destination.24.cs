using System;

namespace behaviac
{
	// Token: 0x02002FF2 RID: 12274
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node35 : Action
	{
		// Token: 0x060148AF RID: 84143 RVA: 0x0062EBD5 File Offset: 0x0062CFD5
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node35()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060148B0 RID: 84144 RVA: 0x0062EBEB File Offset: 0x0062CFEB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E20F RID: 57871
		private DestinationType method_p0;
	}
}
