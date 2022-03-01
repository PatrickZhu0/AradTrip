using System;

namespace behaviac
{
	// Token: 0x02002200 RID: 8704
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_normal_Move_node3 : Action
	{
		// Token: 0x06012D8B RID: 77195 RVA: 0x0058C873 File Offset: 0x0058AC73
		public Action_bt_AutoFight_AutoFight_Fight_normal_Move_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06012D8C RID: 77196 RVA: 0x0058C889 File Offset: 0x0058AC89
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C778 RID: 51064
		private DestinationType method_p0;
	}
}
