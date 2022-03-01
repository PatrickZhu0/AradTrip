using System;

namespace behaviac
{
	// Token: 0x0200301A RID: 12314
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node23 : Action
	{
		// Token: 0x060148FD RID: 84221 RVA: 0x006307A1 File Offset: 0x0062EBA1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x060148FE RID: 84222 RVA: 0x006307B7 File Offset: 0x0062EBB7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E25C RID: 57948
		private DestinationType method_p0;
	}
}
