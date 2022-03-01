using System;

namespace behaviac
{
	// Token: 0x02003383 RID: 13187
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12 : Action
	{
		// Token: 0x06014F63 RID: 85859 RVA: 0x00650AF2 File Offset: 0x0064EEF2
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06014F64 RID: 85860 RVA: 0x00650B08 File Offset: 0x0064EF08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E830 RID: 59440
		private DestinationType method_p0;
	}
}
