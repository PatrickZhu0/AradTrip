using System;

namespace behaviac
{
	// Token: 0x020039B6 RID: 14774
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node15 : Action
	{
		// Token: 0x06015B3F RID: 88895 RVA: 0x0068E11F File Offset: 0x0068C51F
		public Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06015B40 RID: 88896 RVA: 0x0068E135 File Offset: 0x0068C535
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B0 RID: 62640
		private DestinationType method_p0;
	}
}
