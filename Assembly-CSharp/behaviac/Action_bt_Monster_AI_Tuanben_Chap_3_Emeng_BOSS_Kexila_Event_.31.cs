using System;

namespace behaviac
{
	// Token: 0x020038CC RID: 14540
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node5 : Action
	{
		// Token: 0x06015977 RID: 88439 RVA: 0x0068442F File Offset: 0x0068282F
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06015978 RID: 88440 RVA: 0x00684450 File Offset: 0x00682850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F32E RID: 62254
		private int method_p0;

		// Token: 0x0400F32F RID: 62255
		private int method_p1;
	}
}
