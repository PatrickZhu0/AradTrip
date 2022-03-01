using System;

namespace behaviac
{
	// Token: 0x02002D25 RID: 11557
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4 : Action
	{
		// Token: 0x06014335 RID: 82741 RVA: 0x0061177A File Offset: 0x0060FB7A
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 96;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014336 RID: 82742 RVA: 0x006117AE File Offset: 0x0060FBAE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCEE RID: 56558
		private BE_Target method_p0;

		// Token: 0x0400DCEF RID: 56559
		private int method_p1;

		// Token: 0x0400DCF0 RID: 56560
		private int method_p2;

		// Token: 0x0400DCF1 RID: 56561
		private int method_p3;

		// Token: 0x0400DCF2 RID: 56562
		private int method_p4;
	}
}
