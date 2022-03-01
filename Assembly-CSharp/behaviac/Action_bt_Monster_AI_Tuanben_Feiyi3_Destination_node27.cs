using System;

namespace behaviac
{
	// Token: 0x020039BA RID: 14778
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node27 : Action
	{
		// Token: 0x06015B47 RID: 88903 RVA: 0x0068E1FF File Offset: 0x0068C5FF
		public Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06015B48 RID: 88904 RVA: 0x0068E215 File Offset: 0x0068C615
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B4 RID: 62644
		private DestinationType method_p0;
	}
}
