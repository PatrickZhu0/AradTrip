using System;

namespace behaviac
{
	// Token: 0x020021FB RID: 8699
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_hard_Move_node3 : Action
	{
		// Token: 0x06012D82 RID: 77186 RVA: 0x0058C5EF File Offset: 0x0058A9EF
		public Action_bt_AutoFight_AutoFight_Fight_hard_Move_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06012D83 RID: 77187 RVA: 0x0058C605 File Offset: 0x0058AA05
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C774 RID: 51060
		private DestinationType method_p0;
	}
}
