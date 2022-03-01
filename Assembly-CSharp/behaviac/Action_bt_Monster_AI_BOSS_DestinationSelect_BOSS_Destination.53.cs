using System;

namespace behaviac
{
	// Token: 0x0200304A RID: 12362
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node15 : Action
	{
		// Token: 0x0601495B RID: 84315 RVA: 0x006327B9 File Offset: 0x00630BB9
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x0601495C RID: 84316 RVA: 0x006327CF File Offset: 0x00630BCF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2BA RID: 58042
		private DestinationType method_p0;
	}
}
