using System;

namespace behaviac
{
	// Token: 0x02003682 RID: 13954
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node3 : Action
	{
		// Token: 0x06015524 RID: 87332 RVA: 0x0066E686 File Offset: 0x0066CA86
		public Action_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521204;
			this.method_p2 = 5000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015525 RID: 87333 RVA: 0x0066E6C0 File Offset: 0x0066CAC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEDD RID: 61149
		private BE_Target method_p0;

		// Token: 0x0400EEDE RID: 61150
		private int method_p1;

		// Token: 0x0400EEDF RID: 61151
		private int method_p2;

		// Token: 0x0400EEE0 RID: 61152
		private int method_p3;

		// Token: 0x0400EEE1 RID: 61153
		private int method_p4;
	}
}
