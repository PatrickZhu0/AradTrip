using System;

namespace behaviac
{
	// Token: 0x0200394E RID: 14670
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node10 : Action
	{
		// Token: 0x06015A76 RID: 88694 RVA: 0x0068A882 File Offset: 0x00688C82
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node10()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 0;
		}

		// Token: 0x06015A77 RID: 88695 RVA: 0x0068A8A4 File Offset: 0x00688CA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F407 RID: 62471
		private int method_p0;

		// Token: 0x0400F408 RID: 62472
		private int method_p1;
	}
}
