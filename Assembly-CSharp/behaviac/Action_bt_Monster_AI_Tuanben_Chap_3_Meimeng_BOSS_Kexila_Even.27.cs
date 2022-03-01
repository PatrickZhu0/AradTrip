using System;

namespace behaviac
{
	// Token: 0x02003979 RID: 14713
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node17 : Action
	{
		// Token: 0x06015AC9 RID: 88777 RVA: 0x0068B87F File Offset: 0x00689C7F
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 4000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015ACA RID: 88778 RVA: 0x0068B8B7 File Offset: 0x00689CB7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F46F RID: 62575
		private BE_Target method_p0;

		// Token: 0x0400F470 RID: 62576
		private int method_p1;

		// Token: 0x0400F471 RID: 62577
		private int method_p2;

		// Token: 0x0400F472 RID: 62578
		private int method_p3;

		// Token: 0x0400F473 RID: 62579
		private int method_p4;
	}
}
