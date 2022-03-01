using System;

namespace behaviac
{
	// Token: 0x0200344C RID: 13388
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node33 : Action
	{
		// Token: 0x060150E4 RID: 86244 RVA: 0x00658246 File Offset: 0x00656646
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node33()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 0;
		}

		// Token: 0x060150E5 RID: 86245 RVA: 0x00658268 File Offset: 0x00656668
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E9BE RID: 59838
		private int method_p0;

		// Token: 0x0400E9BF RID: 59839
		private int method_p1;
	}
}
