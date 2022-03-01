using System;

namespace behaviac
{
	// Token: 0x020039C0 RID: 14784
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node6 : Action
	{
		// Token: 0x06015B52 RID: 88914 RVA: 0x0068E806 File Offset: 0x0068CC06
		public Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015B53 RID: 88915 RVA: 0x0068E81C File Offset: 0x0068CC1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B6 RID: 62646
		private DestinationType method_p0;
	}
}
