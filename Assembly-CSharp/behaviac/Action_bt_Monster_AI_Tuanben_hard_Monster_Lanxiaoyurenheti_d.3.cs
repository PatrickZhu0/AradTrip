using System;

namespace behaviac
{
	// Token: 0x02003D35 RID: 15669
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node6 : Action
	{
		// Token: 0x06016203 RID: 90627 RVA: 0x006B04E1 File Offset: 0x006AE8E1
		public Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06016204 RID: 90628 RVA: 0x006B04F8 File Offset: 0x006AE8F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA77 RID: 64119
		private DestinationType method_p0;
	}
}
