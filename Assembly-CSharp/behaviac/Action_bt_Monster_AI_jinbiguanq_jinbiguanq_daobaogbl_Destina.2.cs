using System;

namespace behaviac
{
	// Token: 0x02003584 RID: 13700
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node10 : Action
	{
		// Token: 0x0601533A RID: 86842 RVA: 0x00663D5D File Offset: 0x0066215D
		public Action_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x0601533B RID: 86843 RVA: 0x00663D73 File Offset: 0x00662173
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECFD RID: 60669
		private DestinationType method_p0;
	}
}
