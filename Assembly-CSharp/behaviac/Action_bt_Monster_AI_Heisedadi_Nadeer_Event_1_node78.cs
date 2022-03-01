using System;

namespace behaviac
{
	// Token: 0x02003531 RID: 13617
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node78 : Action
	{
		// Token: 0x060152A5 RID: 86693 RVA: 0x0065FDB4 File Offset: 0x0065E1B4
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node78()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521743;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152A6 RID: 86694 RVA: 0x0065FDEB File Offset: 0x0065E1EB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC33 RID: 60467
		private BE_Target method_p0;

		// Token: 0x0400EC34 RID: 60468
		private int method_p1;

		// Token: 0x0400EC35 RID: 60469
		private int method_p2;

		// Token: 0x0400EC36 RID: 60470
		private int method_p3;

		// Token: 0x0400EC37 RID: 60471
		private int method_p4;
	}
}
