using System;

namespace behaviac
{
	// Token: 0x02001F73 RID: 8051
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_foolish_Move_node2 : Action
	{
		// Token: 0x06012887 RID: 75911 RVA: 0x0056D6F3 File Offset: 0x0056BAF3
		public Action_bt_AutoFight_AutoFight_Fight_foolish_Move_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06012888 RID: 75912 RVA: 0x0056D709 File Offset: 0x0056BB09
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C27D RID: 49789
		private DestinationType method_p0;
	}
}
