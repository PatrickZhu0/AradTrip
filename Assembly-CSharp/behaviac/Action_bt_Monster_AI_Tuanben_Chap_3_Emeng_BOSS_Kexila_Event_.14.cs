using System;

namespace behaviac
{
	// Token: 0x020038B3 RID: 14515
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node37 : Action
	{
		// Token: 0x06015945 RID: 88389 RVA: 0x00683BE7 File Offset: 0x00681FE7
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570218;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015946 RID: 88390 RVA: 0x00683C1E File Offset: 0x0068201E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2E6 RID: 62182
		private BE_Target method_p0;

		// Token: 0x0400F2E7 RID: 62183
		private int method_p1;

		// Token: 0x0400F2E8 RID: 62184
		private int method_p2;

		// Token: 0x0400F2E9 RID: 62185
		private int method_p3;

		// Token: 0x0400F2EA RID: 62186
		private int method_p4;
	}
}
