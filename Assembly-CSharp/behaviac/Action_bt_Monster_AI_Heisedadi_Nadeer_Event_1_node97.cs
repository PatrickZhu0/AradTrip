using System;

namespace behaviac
{
	// Token: 0x0200353C RID: 13628
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node97 : Action
	{
		// Token: 0x060152BB RID: 86715 RVA: 0x006601B2 File Offset: 0x0065E5B2
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node97()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521784;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152BC RID: 86716 RVA: 0x006601E9 File Offset: 0x0065E5E9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC61 RID: 60513
		private BE_Target method_p0;

		// Token: 0x0400EC62 RID: 60514
		private int method_p1;

		// Token: 0x0400EC63 RID: 60515
		private int method_p2;

		// Token: 0x0400EC64 RID: 60516
		private int method_p3;

		// Token: 0x0400EC65 RID: 60517
		private int method_p4;
	}
}
