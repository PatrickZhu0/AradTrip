using System;

namespace behaviac
{
	// Token: 0x02003379 RID: 13177
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2 : Action
	{
		// Token: 0x06014F4F RID: 85839 RVA: 0x00650786 File Offset: 0x0064EB86
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06014F50 RID: 85840 RVA: 0x0065079C File Offset: 0x0064EB9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E814 RID: 59412
		private DestinationType method_p0;
	}
}
