using System;

namespace behaviac
{
	// Token: 0x02003BE6 RID: 15334
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node52 : Action
	{
		// Token: 0x06015F79 RID: 89977 RVA: 0x006A2FBF File Offset: 0x006A13BF
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node52()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570207;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015F7A RID: 89978 RVA: 0x006A2FF9 File Offset: 0x006A13F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F813 RID: 63507
		private BE_Target method_p0;

		// Token: 0x0400F814 RID: 63508
		private int method_p1;

		// Token: 0x0400F815 RID: 63509
		private int method_p2;

		// Token: 0x0400F816 RID: 63510
		private int method_p3;

		// Token: 0x0400F817 RID: 63511
		private int method_p4;
	}
}
