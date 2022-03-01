using System;

namespace behaviac
{
	// Token: 0x020039B4 RID: 14772
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node14 : Action
	{
		// Token: 0x06015B3B RID: 88891 RVA: 0x0068E0AC File Offset: 0x0068C4AC
		public Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015B3C RID: 88892 RVA: 0x0068E0C2 File Offset: 0x0068C4C2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4AE RID: 62638
		private DestinationType method_p0;
	}
}
