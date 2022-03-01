using System;

namespace behaviac
{
	// Token: 0x02003581 RID: 13697
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node9 : Action
	{
		// Token: 0x06015334 RID: 86836 RVA: 0x00663C71 File Offset: 0x00662071
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06015335 RID: 86837 RVA: 0x00663C87 File Offset: 0x00662087
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECF7 RID: 60663
		private DestinationType method_p0;
	}
}
