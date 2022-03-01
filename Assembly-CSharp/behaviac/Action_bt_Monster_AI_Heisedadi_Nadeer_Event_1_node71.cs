using System;

namespace behaviac
{
	// Token: 0x0200352A RID: 13610
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node71 : Action
	{
		// Token: 0x06015297 RID: 86679 RVA: 0x0065FAFF File Offset: 0x0065DEFF
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node71()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521785;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015298 RID: 86680 RVA: 0x0065FB36 File Offset: 0x0065DF36
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC10 RID: 60432
		private BE_Target method_p0;

		// Token: 0x0400EC11 RID: 60433
		private int method_p1;

		// Token: 0x0400EC12 RID: 60434
		private int method_p2;

		// Token: 0x0400EC13 RID: 60435
		private int method_p3;

		// Token: 0x0400EC14 RID: 60436
		private int method_p4;
	}
}
