using System;

namespace behaviac
{
	// Token: 0x02002FF0 RID: 12272
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node31 : Action
	{
		// Token: 0x060148AB RID: 84139 RVA: 0x0062EB31 File Offset: 0x0062CF31
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060148AC RID: 84140 RVA: 0x0062EB47 File Offset: 0x0062CF47
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E20A RID: 57866
		private DestinationType method_p0;
	}
}
