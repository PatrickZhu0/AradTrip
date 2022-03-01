using System;

namespace behaviac
{
	// Token: 0x02002F01 RID: 12033
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node6 : Action
	{
		// Token: 0x060146DA RID: 83674 RVA: 0x00624EBE File Offset: 0x006232BE
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570296;
			this.method_p2 = 100;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060146DB RID: 83675 RVA: 0x00624EF5 File Offset: 0x006232F5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E04F RID: 57423
		private BE_Target method_p0;

		// Token: 0x0400E050 RID: 57424
		private int method_p1;

		// Token: 0x0400E051 RID: 57425
		private int method_p2;

		// Token: 0x0400E052 RID: 57426
		private int method_p3;

		// Token: 0x0400E053 RID: 57427
		private int method_p4;
	}
}
