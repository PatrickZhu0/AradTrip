using System;

namespace behaviac
{
	// Token: 0x02003B16 RID: 15126
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node6 : Action
	{
		// Token: 0x06015DE5 RID: 89573 RVA: 0x0069B9C1 File Offset: 0x00699DC1
		public Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015DE6 RID: 89574 RVA: 0x0069B9D8 File Offset: 0x00699DD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6CF RID: 63183
		private DestinationType method_p0;
	}
}
