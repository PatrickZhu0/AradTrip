using System;

namespace behaviac
{
	// Token: 0x0200248D RID: 9357
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9 : Action
	{
		// Token: 0x06013267 RID: 78439 RVA: 0x005AEED7 File Offset: 0x005AD2D7
		public Action_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06013268 RID: 78440 RVA: 0x005AEEED File Offset: 0x005AD2ED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC83 RID: 52355
		private DestinationType method_p0;
	}
}
