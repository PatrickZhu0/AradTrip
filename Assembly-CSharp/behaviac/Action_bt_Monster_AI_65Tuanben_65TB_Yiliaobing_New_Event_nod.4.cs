using System;

namespace behaviac
{
	// Token: 0x02002D2E RID: 11566
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node3 : Action
	{
		// Token: 0x06014345 RID: 82757 RVA: 0x00611CBF File Offset: 0x006100BF
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522111;
			this.method_p2 = 500;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014346 RID: 82758 RVA: 0x00611CFA File Offset: 0x006100FA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD05 RID: 56581
		private BE_Target method_p0;

		// Token: 0x0400DD06 RID: 56582
		private int method_p1;

		// Token: 0x0400DD07 RID: 56583
		private int method_p2;

		// Token: 0x0400DD08 RID: 56584
		private int method_p3;

		// Token: 0x0400DD09 RID: 56585
		private int method_p4;
	}
}
