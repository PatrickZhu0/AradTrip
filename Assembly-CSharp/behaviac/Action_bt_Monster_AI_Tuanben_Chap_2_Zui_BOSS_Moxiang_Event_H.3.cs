using System;

namespace behaviac
{
	// Token: 0x020037A6 RID: 14246
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node10 : Action
	{
		// Token: 0x0601574F RID: 87887 RVA: 0x00679D9C File Offset: 0x0067819C
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node10()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 1;
		}

		// Token: 0x06015750 RID: 87888 RVA: 0x00679DC0 File Offset: 0x006781C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F101 RID: 61697
		private int method_p0;

		// Token: 0x0400F102 RID: 61698
		private int method_p1;
	}
}
