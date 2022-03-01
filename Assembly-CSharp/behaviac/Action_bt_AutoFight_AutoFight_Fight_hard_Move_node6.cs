using System;

namespace behaviac
{
	// Token: 0x020021FD RID: 8701
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_hard_Move_node6 : Action
	{
		// Token: 0x06012D86 RID: 77190 RVA: 0x0058C65F File Offset: 0x0058AA5F
		public Action_bt_AutoFight_AutoFight_Fight_hard_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06012D87 RID: 77191 RVA: 0x0058C675 File Offset: 0x0058AA75
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C776 RID: 51062
		private DestinationType method_p0;
	}
}
