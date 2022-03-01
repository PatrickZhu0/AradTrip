using System;

namespace behaviac
{
	// Token: 0x0200355C RID: 13660
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node1 : Action
	{
		// Token: 0x060152F5 RID: 86773 RVA: 0x00662980 File Offset: 0x00660D80
		public Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 90000;
			this.method_p1 = 0;
		}

		// Token: 0x060152F6 RID: 86774 RVA: 0x006629A4 File Offset: 0x00660DA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECA5 RID: 60581
		private int method_p0;

		// Token: 0x0400ECA6 RID: 60582
		private int method_p1;
	}
}
