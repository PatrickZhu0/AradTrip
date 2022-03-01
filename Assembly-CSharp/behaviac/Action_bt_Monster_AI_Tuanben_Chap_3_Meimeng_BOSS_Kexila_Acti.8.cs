using System;

namespace behaviac
{
	// Token: 0x020038E9 RID: 14569
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node63 : Action
	{
		// Token: 0x060159AF RID: 88495 RVA: 0x0068599F File Offset: 0x00683D9F
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node63()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521648;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060159B0 RID: 88496 RVA: 0x006859D6 File Offset: 0x00683DD6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F35B RID: 62299
		private BE_Target method_p0;

		// Token: 0x0400F35C RID: 62300
		private int method_p1;

		// Token: 0x0400F35D RID: 62301
		private int method_p2;

		// Token: 0x0400F35E RID: 62302
		private int method_p3;

		// Token: 0x0400F35F RID: 62303
		private int method_p4;
	}
}
