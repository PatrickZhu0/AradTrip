using System;

namespace behaviac
{
	// Token: 0x020038C5 RID: 14533
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node2 : Action
	{
		// Token: 0x06015969 RID: 88425 RVA: 0x00684176 File Offset: 0x00682576
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521673;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601596A RID: 88426 RVA: 0x006841AE File Offset: 0x006825AE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F318 RID: 62232
		private BE_Target method_p0;

		// Token: 0x0400F319 RID: 62233
		private int method_p1;

		// Token: 0x0400F31A RID: 62234
		private int method_p2;

		// Token: 0x0400F31B RID: 62235
		private int method_p3;

		// Token: 0x0400F31C RID: 62236
		private int method_p4;
	}
}
