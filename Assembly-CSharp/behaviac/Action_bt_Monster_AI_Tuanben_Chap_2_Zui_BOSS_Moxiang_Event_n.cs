using System;

namespace behaviac
{
	// Token: 0x0200378D RID: 14221
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node1 : Action
	{
		// Token: 0x0601571F RID: 87839 RVA: 0x00678FCF File Offset: 0x006773CF
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 44900;
			this.method_p1 = 0;
		}

		// Token: 0x06015720 RID: 87840 RVA: 0x00678FF0 File Offset: 0x006773F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F0D5 RID: 61653
		private int method_p0;

		// Token: 0x0400F0D6 RID: 61654
		private int method_p1;
	}
}
