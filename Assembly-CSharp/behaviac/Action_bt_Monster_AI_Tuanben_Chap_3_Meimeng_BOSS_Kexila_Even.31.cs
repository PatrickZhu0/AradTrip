using System;

namespace behaviac
{
	// Token: 0x02003983 RID: 14723
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node11 : Action
	{
		// Token: 0x06015ADD RID: 88797 RVA: 0x0068BB6A File Offset: 0x00689F6A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521680;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015ADE RID: 88798 RVA: 0x0068BBA1 File Offset: 0x00689FA1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F47E RID: 62590
		private BE_Target method_p0;

		// Token: 0x0400F47F RID: 62591
		private int method_p1;

		// Token: 0x0400F480 RID: 62592
		private int method_p2;

		// Token: 0x0400F481 RID: 62593
		private int method_p3;

		// Token: 0x0400F482 RID: 62594
		private int method_p4;
	}
}
