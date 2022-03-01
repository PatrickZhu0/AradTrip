using System;

namespace behaviac
{
	// Token: 0x02003C55 RID: 15445
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node47 : Action
	{
		// Token: 0x06016052 RID: 90194 RVA: 0x006A7CC2 File Offset: 0x006A60C2
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016053 RID: 90195 RVA: 0x006A7CF9 File Offset: 0x006A60F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8C8 RID: 63688
		private BE_Target method_p0;

		// Token: 0x0400F8C9 RID: 63689
		private int method_p1;

		// Token: 0x0400F8CA RID: 63690
		private int method_p2;

		// Token: 0x0400F8CB RID: 63691
		private int method_p3;

		// Token: 0x0400F8CC RID: 63692
		private int method_p4;
	}
}
