using System;

namespace behaviac
{
	// Token: 0x020039AD RID: 14765
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node10 : Action
	{
		// Token: 0x06015B2D RID: 88877 RVA: 0x0068DF4D File Offset: 0x0068C34D
		public Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.MOVETO_LEFT_SCENEEDGE;
		}

		// Token: 0x06015B2E RID: 88878 RVA: 0x0068DF64 File Offset: 0x0068C364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4AC RID: 62636
		private DestinationType method_p0;
	}
}
