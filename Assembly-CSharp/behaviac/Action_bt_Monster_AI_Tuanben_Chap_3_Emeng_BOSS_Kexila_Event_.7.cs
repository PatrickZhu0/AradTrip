using System;

namespace behaviac
{
	// Token: 0x020038A4 RID: 14500
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5 : Action
	{
		// Token: 0x0601592A RID: 88362 RVA: 0x0068335B File Offset: 0x0068175B
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x0601592B RID: 88363 RVA: 0x0068337C File Offset: 0x0068177C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F2C5 RID: 62149
		private int method_p0;

		// Token: 0x0400F2C6 RID: 62150
		private int method_p1;
	}
}
