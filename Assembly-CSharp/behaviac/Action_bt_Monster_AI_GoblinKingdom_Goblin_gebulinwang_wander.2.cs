using System;

namespace behaviac
{
	// Token: 0x02003331 RID: 13105
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node6 : Action
	{
		// Token: 0x06014EC7 RID: 85703 RVA: 0x0064DE4F File Offset: 0x0064C24F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014EC8 RID: 85704 RVA: 0x0064DE65 File Offset: 0x0064C265
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7AD RID: 59309
		private DestinationType method_p0;
	}
}
