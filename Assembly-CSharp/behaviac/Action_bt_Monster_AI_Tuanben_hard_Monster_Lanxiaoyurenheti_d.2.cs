using System;

namespace behaviac
{
	// Token: 0x02003D34 RID: 15668
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2 : Action
	{
		// Token: 0x06016201 RID: 90625 RVA: 0x006B04B6 File Offset: 0x006AE8B6
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06016202 RID: 90626 RVA: 0x006B04CD File Offset: 0x006AE8CD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA76 RID: 64118
		private DestinationType method_p0;
	}
}
