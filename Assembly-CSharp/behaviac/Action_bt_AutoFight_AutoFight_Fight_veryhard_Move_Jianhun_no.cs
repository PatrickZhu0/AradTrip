using System;

namespace behaviac
{
	// Token: 0x02002485 RID: 9349
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node22 : Action
	{
		// Token: 0x06013257 RID: 78423 RVA: 0x005AEC0B File Offset: 0x005AD00B
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER_PKROBOT;
		}

		// Token: 0x06013258 RID: 78424 RVA: 0x005AEC22 File Offset: 0x005AD022
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC73 RID: 52339
		private DestinationType method_p0;
	}
}
