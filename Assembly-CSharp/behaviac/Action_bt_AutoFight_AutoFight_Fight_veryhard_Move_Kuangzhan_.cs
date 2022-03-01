using System;

namespace behaviac
{
	// Token: 0x02002492 RID: 9362
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node22 : Action
	{
		// Token: 0x06013270 RID: 78448 RVA: 0x005AF407 File Offset: 0x005AD807
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER_PKROBOT;
		}

		// Token: 0x06013271 RID: 78449 RVA: 0x005AF41E File Offset: 0x005AD81E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC8A RID: 52362
		private DestinationType method_p0;
	}
}
