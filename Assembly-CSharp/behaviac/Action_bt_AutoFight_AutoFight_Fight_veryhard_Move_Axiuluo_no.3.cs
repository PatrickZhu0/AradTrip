using System;

namespace behaviac
{
	// Token: 0x02002480 RID: 9344
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node9 : Action
	{
		// Token: 0x0601324E RID: 78414 RVA: 0x005AE6DB File Offset: 0x005ACADB
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x0601324F RID: 78415 RVA: 0x005AE6F1 File Offset: 0x005ACAF1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC6C RID: 52332
		private DestinationType method_p0;
	}
}
