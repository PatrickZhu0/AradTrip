using System;

namespace behaviac
{
	// Token: 0x02003BCD RID: 15309
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node37 : Action
	{
		// Token: 0x06015F47 RID: 89927 RVA: 0x006A289B File Offset: 0x006A0C9B
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570218;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015F48 RID: 89928 RVA: 0x006A28D2 File Offset: 0x006A0CD2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7DA RID: 63450
		private BE_Target method_p0;

		// Token: 0x0400F7DB RID: 63451
		private int method_p1;

		// Token: 0x0400F7DC RID: 63452
		private int method_p2;

		// Token: 0x0400F7DD RID: 63453
		private int method_p3;

		// Token: 0x0400F7DE RID: 63454
		private int method_p4;
	}
}
