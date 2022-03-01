using System;

namespace behaviac
{
	// Token: 0x020039C4 RID: 14788
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node14 : Action
	{
		// Token: 0x06015B5A RID: 88922 RVA: 0x0068E8D0 File Offset: 0x0068CCD0
		public Action_bt_Monster_AI_Tuanben_Feiyi_Destination_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015B5B RID: 88923 RVA: 0x0068E8E6 File Offset: 0x0068CCE6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B7 RID: 62647
		private DestinationType method_p0;
	}
}
