using System;

namespace behaviac
{
	// Token: 0x0200304D RID: 12365
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node19 : Action
	{
		// Token: 0x06014961 RID: 84321 RVA: 0x006328A5 File Offset: 0x00630CA5
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014962 RID: 84322 RVA: 0x006328BB File Offset: 0x00630CBB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2C0 RID: 58048
		private DestinationType method_p0;
	}
}
