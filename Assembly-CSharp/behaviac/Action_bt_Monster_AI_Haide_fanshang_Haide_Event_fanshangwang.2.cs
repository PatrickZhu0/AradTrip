using System;

namespace behaviac
{
	// Token: 0x020033E1 RID: 13281
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node11 : Action
	{
		// Token: 0x06015017 RID: 86039 RVA: 0x00654261 File Offset: 0x00652661
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2504;
			this.method_p2 = 4000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015018 RID: 86040 RVA: 0x0065429B File Offset: 0x0065269B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E902 RID: 59650
		private BE_Target method_p0;

		// Token: 0x0400E903 RID: 59651
		private int method_p1;

		// Token: 0x0400E904 RID: 59652
		private int method_p2;

		// Token: 0x0400E905 RID: 59653
		private int method_p3;

		// Token: 0x0400E906 RID: 59654
		private int method_p4;
	}
}
