using System;

namespace behaviac
{
	// Token: 0x02003170 RID: 12656
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node2 : Action
	{
		// Token: 0x06014B77 RID: 84855 RVA: 0x0063D2CE File Offset: 0x0063B6CE
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014B78 RID: 84856 RVA: 0x0063D2E4 File Offset: 0x0063B6E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4ED RID: 58605
		private int method_p0;
	}
}
