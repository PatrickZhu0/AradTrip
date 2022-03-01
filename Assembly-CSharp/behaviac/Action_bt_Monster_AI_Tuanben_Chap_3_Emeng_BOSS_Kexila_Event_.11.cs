using System;

namespace behaviac
{
	// Token: 0x020038AE RID: 14510
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node34 : Action
	{
		// Token: 0x0601593B RID: 88379 RVA: 0x00683A23 File Offset: 0x00681E23
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570215;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601593C RID: 88380 RVA: 0x00683A5A File Offset: 0x00681E5A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2D5 RID: 62165
		private BE_Target method_p0;

		// Token: 0x0400F2D6 RID: 62166
		private int method_p1;

		// Token: 0x0400F2D7 RID: 62167
		private int method_p2;

		// Token: 0x0400F2D8 RID: 62168
		private int method_p3;

		// Token: 0x0400F2D9 RID: 62169
		private int method_p4;
	}
}
