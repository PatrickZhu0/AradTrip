using System;

namespace behaviac
{
	// Token: 0x02003587 RID: 13703
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node15 : Action
	{
		// Token: 0x06015340 RID: 86848 RVA: 0x00663E49 File Offset: 0x00662249
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06015341 RID: 86849 RVA: 0x00663E5F File Offset: 0x0066225F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED03 RID: 60675
		private DestinationType method_p0;
	}
}
