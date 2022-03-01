using System;

namespace behaviac
{
	// Token: 0x0200358A RID: 13706
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node18 : Action
	{
		// Token: 0x06015346 RID: 86854 RVA: 0x00663F35 File Offset: 0x00662335
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06015347 RID: 86855 RVA: 0x00663F4B File Offset: 0x0066234B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED09 RID: 60681
		private DestinationType method_p0;
	}
}
