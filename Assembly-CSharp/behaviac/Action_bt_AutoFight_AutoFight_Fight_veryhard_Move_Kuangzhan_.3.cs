using System;

namespace behaviac
{
	// Token: 0x0200249A RID: 9370
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node15 : Action
	{
		// Token: 0x06013280 RID: 78464 RVA: 0x005AF6BB File Offset: 0x005ADABB
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013281 RID: 78465 RVA: 0x005AF6D1 File Offset: 0x005ADAD1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC98 RID: 52376
		private DestinationType method_p0;
	}
}
