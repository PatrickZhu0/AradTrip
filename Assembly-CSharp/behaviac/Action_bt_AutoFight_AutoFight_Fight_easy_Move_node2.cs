using System;

namespace behaviac
{
	// Token: 0x02001F6E RID: 8046
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_easy_Move_node2 : Action
	{
		// Token: 0x0601287E RID: 75902 RVA: 0x0056D46B File Offset: 0x0056B86B
		public Action_bt_AutoFight_AutoFight_Fight_easy_Move_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601287F RID: 75903 RVA: 0x0056D481 File Offset: 0x0056B881
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C279 RID: 49785
		private DestinationType method_p0;
	}
}
