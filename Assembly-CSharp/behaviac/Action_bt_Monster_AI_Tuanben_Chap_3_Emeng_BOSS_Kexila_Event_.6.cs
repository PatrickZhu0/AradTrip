using System;

namespace behaviac
{
	// Token: 0x020038A3 RID: 14499
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4 : Action
	{
		// Token: 0x06015928 RID: 88360 RVA: 0x006832F7 File Offset: 0x006816F7
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521673;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015929 RID: 88361 RVA: 0x0068332F File Offset: 0x0068172F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2C0 RID: 62144
		private BE_Target method_p0;

		// Token: 0x0400F2C1 RID: 62145
		private int method_p1;

		// Token: 0x0400F2C2 RID: 62146
		private int method_p2;

		// Token: 0x0400F2C3 RID: 62147
		private int method_p3;

		// Token: 0x0400F2C4 RID: 62148
		private int method_p4;
	}
}
