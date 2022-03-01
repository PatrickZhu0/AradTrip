using System;

namespace behaviac
{
	// Token: 0x02002BA9 RID: 11177
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2 : Action
	{
		// Token: 0x0601405A RID: 82010 RVA: 0x006036C1 File Offset: 0x00601AC1
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601405B RID: 82011 RVA: 0x006036D7 File Offset: 0x00601AD7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA55 RID: 55893
		private DestinationType method_p0;
	}
}
