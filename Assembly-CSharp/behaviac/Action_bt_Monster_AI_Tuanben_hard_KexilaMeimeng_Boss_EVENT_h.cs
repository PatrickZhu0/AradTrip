using System;

namespace behaviac
{
	// Token: 0x02003C54 RID: 15444
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node34 : Action
	{
		// Token: 0x06016050 RID: 90192 RVA: 0x006A7C5F File Offset: 0x006A605F
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016051 RID: 90193 RVA: 0x006A7C96 File Offset: 0x006A6096
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8C3 RID: 63683
		private BE_Target method_p0;

		// Token: 0x0400F8C4 RID: 63684
		private int method_p1;

		// Token: 0x0400F8C5 RID: 63685
		private int method_p2;

		// Token: 0x0400F8C6 RID: 63686
		private int method_p3;

		// Token: 0x0400F8C7 RID: 63687
		private int method_p4;
	}
}
