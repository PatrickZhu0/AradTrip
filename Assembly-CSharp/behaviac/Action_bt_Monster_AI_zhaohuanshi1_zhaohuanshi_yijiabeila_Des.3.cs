using System;

namespace behaviac
{
	// Token: 0x020040BF RID: 16575
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node14 : Action
	{
		// Token: 0x060168D6 RID: 92374 RVA: 0x006D4385 File Offset: 0x006D2785
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060168D7 RID: 92375 RVA: 0x006D439B File Offset: 0x006D279B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401011E RID: 65822
		private DestinationType method_p0;
	}
}
