using System;

namespace behaviac
{
	// Token: 0x02003047 RID: 12359
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node11 : Action
	{
		// Token: 0x06014955 RID: 84309 RVA: 0x006326CD File Offset: 0x00630ACD
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06014956 RID: 84310 RVA: 0x006326E3 File Offset: 0x00630AE3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2B4 RID: 58036
		private DestinationType method_p0;
	}
}
