using System;

namespace behaviac
{
	// Token: 0x020039A8 RID: 14760
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node15 : Action
	{
		// Token: 0x06015B24 RID: 88868 RVA: 0x0068DA17 File Offset: 0x0068BE17
		public Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06015B25 RID: 88869 RVA: 0x0068DA2D File Offset: 0x0068BE2D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A9 RID: 62633
		private DestinationType method_p0;
	}
}
