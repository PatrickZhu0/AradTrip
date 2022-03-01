using System;

namespace behaviac
{
	// Token: 0x0200249E RID: 9374
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9 : Action
	{
		// Token: 0x06013288 RID: 78472 RVA: 0x005AF803 File Offset: 0x005ADC03
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013289 RID: 78473 RVA: 0x005AF819 File Offset: 0x005ADC19
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCA1 RID: 52385
		private DestinationType method_p0;
	}
}
