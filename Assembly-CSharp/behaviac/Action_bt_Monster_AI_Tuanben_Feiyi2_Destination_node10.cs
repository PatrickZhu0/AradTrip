using System;

namespace behaviac
{
	// Token: 0x0200399F RID: 14751
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node10 : Action
	{
		// Token: 0x06015B12 RID: 88850 RVA: 0x0068D65D File Offset: 0x0068BA5D
		public Action_bt_Monster_AI_Tuanben_Feiyi2_Destination_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.MOVETO_LEFT_SCENEEDGE;
		}

		// Token: 0x06015B13 RID: 88851 RVA: 0x0068D674 File Offset: 0x0068BA74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A5 RID: 62629
		private DestinationType method_p0;
	}
}
