using System;

namespace behaviac
{
	// Token: 0x020038B4 RID: 14516
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node48 : Action
	{
		// Token: 0x06015947 RID: 88391 RVA: 0x00683C4A File Offset: 0x0068204A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015948 RID: 88392 RVA: 0x00683C81 File Offset: 0x00682081
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2EB RID: 62187
		private BE_Target method_p0;

		// Token: 0x0400F2EC RID: 62188
		private int method_p1;

		// Token: 0x0400F2ED RID: 62189
		private int method_p2;

		// Token: 0x0400F2EE RID: 62190
		private int method_p3;

		// Token: 0x0400F2EF RID: 62191
		private int method_p4;
	}
}
