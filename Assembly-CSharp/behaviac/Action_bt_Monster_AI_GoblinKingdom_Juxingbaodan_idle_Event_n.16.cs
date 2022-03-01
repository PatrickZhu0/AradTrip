using System;

namespace behaviac
{
	// Token: 0x0200338D RID: 13197
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17 : Action
	{
		// Token: 0x06014F77 RID: 85879 RVA: 0x00650E5E File Offset: 0x0064F25E
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06014F78 RID: 85880 RVA: 0x00650E74 File Offset: 0x0064F274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E84C RID: 59468
		private DestinationType method_p0;
	}
}
