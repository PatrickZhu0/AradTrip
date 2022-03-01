using System;

namespace behaviac
{
	// Token: 0x02003CBD RID: 15549
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node34 : Action
	{
		// Token: 0x0601611C RID: 90396 RVA: 0x006AC213 File Offset: 0x006AA613
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601611D RID: 90397 RVA: 0x006AC24A File Offset: 0x006AA64A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9BE RID: 63934
		private BE_Target method_p0;

		// Token: 0x0400F9BF RID: 63935
		private int method_p1;

		// Token: 0x0400F9C0 RID: 63936
		private int method_p2;

		// Token: 0x0400F9C1 RID: 63937
		private int method_p3;

		// Token: 0x0400F9C2 RID: 63938
		private int method_p4;
	}
}
