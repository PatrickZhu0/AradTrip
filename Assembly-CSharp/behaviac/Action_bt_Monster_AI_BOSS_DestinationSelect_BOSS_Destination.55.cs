using System;

namespace behaviac
{
	// Token: 0x02003050 RID: 12368
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node23 : Action
	{
		// Token: 0x06014967 RID: 84327 RVA: 0x00632991 File Offset: 0x00630D91
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06014968 RID: 84328 RVA: 0x006329A7 File Offset: 0x00630DA7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2C6 RID: 58054
		private DestinationType method_p0;
	}
}
