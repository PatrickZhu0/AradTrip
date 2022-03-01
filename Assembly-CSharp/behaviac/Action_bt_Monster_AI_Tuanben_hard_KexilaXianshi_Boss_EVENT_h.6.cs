using System;

namespace behaviac
{
	// Token: 0x02003CC3 RID: 15555
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node48 : Action
	{
		// Token: 0x06016128 RID: 90408 RVA: 0x006AC43A File Offset: 0x006AA83A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016129 RID: 90409 RVA: 0x006AC471 File Offset: 0x006AA871
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9D4 RID: 63956
		private BE_Target method_p0;

		// Token: 0x0400F9D5 RID: 63957
		private int method_p1;

		// Token: 0x0400F9D6 RID: 63958
		private int method_p2;

		// Token: 0x0400F9D7 RID: 63959
		private int method_p3;

		// Token: 0x0400F9D8 RID: 63960
		private int method_p4;
	}
}
