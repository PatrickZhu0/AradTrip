using System;

namespace behaviac
{
	// Token: 0x020039C6 RID: 14790
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node15 : Action
	{
		// Token: 0x06015B5E RID: 88926 RVA: 0x0068E943 File Offset: 0x0068CD43
		public Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06015B5F RID: 88927 RVA: 0x0068E959 File Offset: 0x0068CD59
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B9 RID: 62649
		private DestinationType method_p0;
	}
}
