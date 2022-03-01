using System;

namespace behaviac
{
	// Token: 0x0200301D RID: 12317
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node27 : Action
	{
		// Token: 0x06014903 RID: 84227 RVA: 0x0063088D File Offset: 0x0062EC8D
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014904 RID: 84228 RVA: 0x006308A3 File Offset: 0x0062ECA3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E262 RID: 57954
		private DestinationType method_p0;
	}
}
