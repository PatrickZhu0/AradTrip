using System;

namespace behaviac
{
	// Token: 0x0200352E RID: 13614
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node75 : Action
	{
		// Token: 0x0601529F RID: 86687 RVA: 0x0065FC8B File Offset: 0x0065E08B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node75()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521789;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152A0 RID: 86688 RVA: 0x0065FCC2 File Offset: 0x0065E0C2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC24 RID: 60452
		private BE_Target method_p0;

		// Token: 0x0400EC25 RID: 60453
		private int method_p1;

		// Token: 0x0400EC26 RID: 60454
		private int method_p2;

		// Token: 0x0400EC27 RID: 60455
		private int method_p3;

		// Token: 0x0400EC28 RID: 60456
		private int method_p4;
	}
}
