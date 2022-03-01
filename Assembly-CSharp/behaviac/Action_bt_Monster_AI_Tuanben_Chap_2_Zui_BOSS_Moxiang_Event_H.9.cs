using System;

namespace behaviac
{
	// Token: 0x020037B5 RID: 14261
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node18 : Action
	{
		// Token: 0x0601576D RID: 87917 RVA: 0x0067A2A3 File Offset: 0x006786A3
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node18()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 6000;
			this.method_p1 = 0;
		}

		// Token: 0x0601576E RID: 87918 RVA: 0x0067A2C4 File Offset: 0x006786C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F11A RID: 61722
		private int method_p0;

		// Token: 0x0400F11B RID: 61723
		private int method_p1;
	}
}
