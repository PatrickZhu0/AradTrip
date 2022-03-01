using System;

namespace behaviac
{
	// Token: 0x0200348A RID: 13450
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node21 : Action
	{
		// Token: 0x0601515D RID: 86365 RVA: 0x0065A4DF File Offset: 0x006588DF
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node21()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1500;
			this.method_p1 = 1;
		}

		// Token: 0x0601515E RID: 86366 RVA: 0x0065A500 File Offset: 0x00658900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA5B RID: 59995
		private int method_p0;

		// Token: 0x0400EA5C RID: 59996
		private int method_p1;
	}
}
