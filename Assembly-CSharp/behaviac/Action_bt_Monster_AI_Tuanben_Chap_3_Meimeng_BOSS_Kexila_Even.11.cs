using System;

namespace behaviac
{
	// Token: 0x0200395C RID: 14684
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node47 : Action
	{
		// Token: 0x06015A8F RID: 88719 RVA: 0x0068AF5A File Offset: 0x0068935A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A90 RID: 88720 RVA: 0x0068AF91 File Offset: 0x00689391
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F428 RID: 62504
		private BE_Target method_p0;

		// Token: 0x0400F429 RID: 62505
		private int method_p1;

		// Token: 0x0400F42A RID: 62506
		private int method_p2;

		// Token: 0x0400F42B RID: 62507
		private int method_p3;

		// Token: 0x0400F42C RID: 62508
		private int method_p4;
	}
}
