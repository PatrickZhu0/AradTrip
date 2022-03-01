using System;

namespace behaviac
{
	// Token: 0x020039CB RID: 14795
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node10 : Action
	{
		// Token: 0x06015B67 RID: 88935 RVA: 0x0068EE78 File Offset: 0x0068D278
		public Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.MOVETO_LEFT_SCENEEDGE;
		}

		// Token: 0x06015B68 RID: 88936 RVA: 0x0068EE8F File Offset: 0x0068D28F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4BC RID: 62652
		private DestinationType method_p0;
	}
}
