using System;

namespace behaviac
{
	// Token: 0x02003537 RID: 13623
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node92 : Action
	{
		// Token: 0x060152B1 RID: 86705 RVA: 0x0065FFC3 File Offset: 0x0065E3C3
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node92()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521785;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152B2 RID: 86706 RVA: 0x0065FFFA File Offset: 0x0065E3FA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC48 RID: 60488
		private BE_Target method_p0;

		// Token: 0x0400EC49 RID: 60489
		private int method_p1;

		// Token: 0x0400EC4A RID: 60490
		private int method_p2;

		// Token: 0x0400EC4B RID: 60491
		private int method_p3;

		// Token: 0x0400EC4C RID: 60492
		private int method_p4;
	}
}
