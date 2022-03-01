using System;

namespace behaviac
{
	// Token: 0x020040BC RID: 16572
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node10 : Action
	{
		// Token: 0x060168D0 RID: 92368 RVA: 0x006D4299 File Offset: 0x006D2699
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060168D1 RID: 92369 RVA: 0x006D42AF File Offset: 0x006D26AF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010118 RID: 65816
		private DestinationType method_p0;
	}
}
