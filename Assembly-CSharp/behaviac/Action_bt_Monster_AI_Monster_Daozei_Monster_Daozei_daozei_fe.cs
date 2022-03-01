using System;

namespace behaviac
{
	// Token: 0x02003681 RID: 13953
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2 : Action
	{
		// Token: 0x06015522 RID: 87330 RVA: 0x0066E623 File Offset: 0x0066CA23
		public Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 34;
			this.method_p2 = 5000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015523 RID: 87331 RVA: 0x0066E65A File Offset: 0x0066CA5A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EED8 RID: 61144
		private BE_Target method_p0;

		// Token: 0x0400EED9 RID: 61145
		private int method_p1;

		// Token: 0x0400EEDA RID: 61146
		private int method_p2;

		// Token: 0x0400EEDB RID: 61147
		private int method_p3;

		// Token: 0x0400EEDC RID: 61148
		private int method_p4;
	}
}
