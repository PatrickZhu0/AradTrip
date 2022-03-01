using System;

namespace behaviac
{
	// Token: 0x02003B5B RID: 15195
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node29 : Action
	{
		// Token: 0x06015E6B RID: 89707 RVA: 0x0069DB43 File Offset: 0x0069BF43
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570070;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015E6C RID: 89708 RVA: 0x0069DB7A File Offset: 0x0069BF7A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F735 RID: 63285
		private BE_Target method_p0;

		// Token: 0x0400F736 RID: 63286
		private int method_p1;

		// Token: 0x0400F737 RID: 63287
		private int method_p2;

		// Token: 0x0400F738 RID: 63288
		private int method_p3;

		// Token: 0x0400F739 RID: 63289
		private int method_p4;
	}
}
