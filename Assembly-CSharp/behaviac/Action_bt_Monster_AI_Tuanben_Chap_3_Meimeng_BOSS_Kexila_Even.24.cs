using System;

namespace behaviac
{
	// Token: 0x02003972 RID: 14706
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node9 : Action
	{
		// Token: 0x06015ABB RID: 88763 RVA: 0x0068B62B File Offset: 0x00689A2B
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 4000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015ABC RID: 88764 RVA: 0x0068B663 File Offset: 0x00689A63
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F462 RID: 62562
		private BE_Target method_p0;

		// Token: 0x0400F463 RID: 62563
		private int method_p1;

		// Token: 0x0400F464 RID: 62564
		private int method_p2;

		// Token: 0x0400F465 RID: 62565
		private int method_p3;

		// Token: 0x0400F466 RID: 62566
		private int method_p4;
	}
}
