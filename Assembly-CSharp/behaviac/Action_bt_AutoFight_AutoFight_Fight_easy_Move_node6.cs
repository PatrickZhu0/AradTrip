using System;

namespace behaviac
{
	// Token: 0x02001F70 RID: 8048
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_easy_Move_node6 : Action
	{
		// Token: 0x06012882 RID: 75906 RVA: 0x0056D4DB File Offset: 0x0056B8DB
		public Action_bt_AutoFight_AutoFight_Fight_easy_Move_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06012883 RID: 75907 RVA: 0x0056D4F1 File Offset: 0x0056B8F1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C27B RID: 49787
		private DestinationType method_p0;
	}
}
