using System;

namespace behaviac
{
	// Token: 0x02001F75 RID: 8053
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_foolish_Move_node6 : Action
	{
		// Token: 0x0601288B RID: 75915 RVA: 0x0056D763 File Offset: 0x0056BB63
		public Action_bt_AutoFight_AutoFight_Fight_foolish_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x0601288C RID: 75916 RVA: 0x0056D779 File Offset: 0x0056BB79
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C27F RID: 49791
		private DestinationType method_p0;
	}
}
