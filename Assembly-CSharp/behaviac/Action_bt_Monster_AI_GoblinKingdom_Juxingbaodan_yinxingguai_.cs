using System;

namespace behaviac
{
	// Token: 0x020033AA RID: 13226
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node2 : Action
	{
		// Token: 0x06014FAE RID: 85934 RVA: 0x00652600 File Offset: 0x00650A00
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_yinxingguai_Destination_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06014FAF RID: 85935 RVA: 0x00652616 File Offset: 0x00650A16
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E88D RID: 59533
		private DestinationType method_p0;
	}
}
