using System;

namespace behaviac
{
	// Token: 0x020039BD RID: 14781
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node10 : Action
	{
		// Token: 0x06015B4C RID: 88908 RVA: 0x0068E771 File Offset: 0x0068CB71
		public Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.MOVETO_LEFT_SCENEEDGE;
		}

		// Token: 0x06015B4D RID: 88909 RVA: 0x0068E788 File Offset: 0x0068CB88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B5 RID: 62645
		private DestinationType method_p0;
	}
}
