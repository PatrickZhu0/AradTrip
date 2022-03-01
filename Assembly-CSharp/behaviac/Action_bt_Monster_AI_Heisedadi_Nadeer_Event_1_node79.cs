using System;

namespace behaviac
{
	// Token: 0x02003532 RID: 13618
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node79 : Action
	{
		// Token: 0x060152A7 RID: 86695 RVA: 0x0065FE17 File Offset: 0x0065E217
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node79()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521765;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152A8 RID: 86696 RVA: 0x0065FE4E File Offset: 0x0065E24E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC38 RID: 60472
		private BE_Target method_p0;

		// Token: 0x0400EC39 RID: 60473
		private int method_p1;

		// Token: 0x0400EC3A RID: 60474
		private int method_p2;

		// Token: 0x0400EC3B RID: 60475
		private int method_p3;

		// Token: 0x0400EC3C RID: 60476
		private int method_p4;
	}
}
