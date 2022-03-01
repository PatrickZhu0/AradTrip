using System;

namespace behaviac
{
	// Token: 0x02003539 RID: 13625
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node94 : Action
	{
		// Token: 0x060152B5 RID: 86709 RVA: 0x00660089 File Offset: 0x0065E489
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node94()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521787;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152B6 RID: 86710 RVA: 0x006600C0 File Offset: 0x0065E4C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC52 RID: 60498
		private BE_Target method_p0;

		// Token: 0x0400EC53 RID: 60499
		private int method_p1;

		// Token: 0x0400EC54 RID: 60500
		private int method_p2;

		// Token: 0x0400EC55 RID: 60501
		private int method_p3;

		// Token: 0x0400EC56 RID: 60502
		private int method_p4;
	}
}
