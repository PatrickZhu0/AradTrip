using System;

namespace behaviac
{
	// Token: 0x02002471 RID: 9329
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_node3 : Action
	{
		// Token: 0x06013231 RID: 78385 RVA: 0x005AE097 File Offset: 0x005AC497
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06013232 RID: 78386 RVA: 0x005AE0AD File Offset: 0x005AC4AD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC53 RID: 52307
		private DestinationType method_p0;
	}
}
