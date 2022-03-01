using System;

namespace behaviac
{
	// Token: 0x02003C0C RID: 15372
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node43 : Action
	{
		// Token: 0x06015FC3 RID: 90051 RVA: 0x006A4B6E File Offset: 0x006A2F6E
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node43()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570049;
			this.method_p2 = -1;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x06015FC4 RID: 90052 RVA: 0x006A4BA5 File Offset: 0x006A2FA5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F843 RID: 63555
		private BE_Target method_p0;

		// Token: 0x0400F844 RID: 63556
		private int method_p1;

		// Token: 0x0400F845 RID: 63557
		private int method_p2;

		// Token: 0x0400F846 RID: 63558
		private int method_p3;

		// Token: 0x0400F847 RID: 63559
		private int method_p4;
	}
}
