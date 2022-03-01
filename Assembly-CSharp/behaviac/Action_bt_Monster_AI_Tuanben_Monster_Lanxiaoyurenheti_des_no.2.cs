using System;

namespace behaviac
{
	// Token: 0x02003B15 RID: 15125
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2 : Action
	{
		// Token: 0x06015DE3 RID: 89571 RVA: 0x0069B996 File Offset: 0x00699D96
		public Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015DE4 RID: 89572 RVA: 0x0069B9AD File Offset: 0x00699DAD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6CE RID: 63182
		private DestinationType method_p0;
	}
}
