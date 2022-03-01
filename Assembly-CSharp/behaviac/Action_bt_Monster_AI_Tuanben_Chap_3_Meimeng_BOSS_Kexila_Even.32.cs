using System;

namespace behaviac
{
	// Token: 0x02003987 RID: 14727
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node28 : Action
	{
		// Token: 0x06015AE5 RID: 88805 RVA: 0x0068BC76 File Offset: 0x0068A076
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521681;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015AE6 RID: 88806 RVA: 0x0068BCAD File Offset: 0x0068A0AD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F484 RID: 62596
		private BE_Target method_p0;

		// Token: 0x0400F485 RID: 62597
		private int method_p1;

		// Token: 0x0400F486 RID: 62598
		private int method_p2;

		// Token: 0x0400F487 RID: 62599
		private int method_p3;

		// Token: 0x0400F488 RID: 62600
		private int method_p4;
	}
}
