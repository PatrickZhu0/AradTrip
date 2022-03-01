using System;

namespace behaviac
{
	// Token: 0x02003BC9 RID: 15305
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node47 : Action
	{
		// Token: 0x06015F3F RID: 89919 RVA: 0x006A273A File Offset: 0x006A0B3A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015F40 RID: 89920 RVA: 0x006A2771 File Offset: 0x006A0B71
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7CE RID: 63438
		private BE_Target method_p0;

		// Token: 0x0400F7CF RID: 63439
		private int method_p1;

		// Token: 0x0400F7D0 RID: 63440
		private int method_p2;

		// Token: 0x0400F7D1 RID: 63441
		private int method_p3;

		// Token: 0x0400F7D2 RID: 63442
		private int method_p4;
	}
}
