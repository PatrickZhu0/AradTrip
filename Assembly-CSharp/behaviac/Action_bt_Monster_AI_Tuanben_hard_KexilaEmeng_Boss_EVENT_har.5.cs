using System;

namespace behaviac
{
	// Token: 0x02003BCE RID: 15310
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node48 : Action
	{
		// Token: 0x06015F49 RID: 89929 RVA: 0x006A28FE File Offset: 0x006A0CFE
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015F4A RID: 89930 RVA: 0x006A2935 File Offset: 0x006A0D35
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7DF RID: 63455
		private BE_Target method_p0;

		// Token: 0x0400F7E0 RID: 63456
		private int method_p1;

		// Token: 0x0400F7E1 RID: 63457
		private int method_p2;

		// Token: 0x0400F7E2 RID: 63458
		private int method_p3;

		// Token: 0x0400F7E3 RID: 63459
		private int method_p4;
	}
}
