using System;

namespace behaviac
{
	// Token: 0x02002473 RID: 9331
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_node6 : Action
	{
		// Token: 0x06013235 RID: 78389 RVA: 0x005AE107 File Offset: 0x005AC507
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013236 RID: 78390 RVA: 0x005AE11D File Offset: 0x005AC51D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC55 RID: 52309
		private DestinationType method_p0;
	}
}
