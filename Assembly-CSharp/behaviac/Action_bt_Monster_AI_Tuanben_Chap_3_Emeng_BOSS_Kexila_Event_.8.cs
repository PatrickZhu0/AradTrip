using System;

namespace behaviac
{
	// Token: 0x020038A5 RID: 14501
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node20 : Action
	{
		// Token: 0x0601592C RID: 88364 RVA: 0x006833A2 File Offset: 0x006817A2
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521641;
			this.method_p2 = 1000;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x0601592D RID: 88365 RVA: 0x006833DD File Offset: 0x006817DD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2C7 RID: 62151
		private BE_Target method_p0;

		// Token: 0x0400F2C8 RID: 62152
		private int method_p1;

		// Token: 0x0400F2C9 RID: 62153
		private int method_p2;

		// Token: 0x0400F2CA RID: 62154
		private int method_p3;

		// Token: 0x0400F2CB RID: 62155
		private int method_p4;
	}
}
