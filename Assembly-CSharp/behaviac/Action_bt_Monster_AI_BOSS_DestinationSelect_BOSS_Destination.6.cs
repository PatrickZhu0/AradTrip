using System;

namespace behaviac
{
	// Token: 0x02002FBD RID: 12221
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node27 : Action
	{
		// Token: 0x06014847 RID: 84039 RVA: 0x0062CBFD File Offset: 0x0062AFFD
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014848 RID: 84040 RVA: 0x0062CC13 File Offset: 0x0062B013
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1A6 RID: 57766
		private DestinationType method_p0;
	}
}
