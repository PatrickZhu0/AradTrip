using System;

namespace behaviac
{
	// Token: 0x02002D35 RID: 11573
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2 : Action
	{
		// Token: 0x06014351 RID: 82769 RVA: 0x006121FA File Offset: 0x006105FA
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521963;
			this.method_p2 = 100;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014352 RID: 82770 RVA: 0x00612232 File Offset: 0x00610632
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD15 RID: 56597
		private BE_Target method_p0;

		// Token: 0x0400DD16 RID: 56598
		private int method_p1;

		// Token: 0x0400DD17 RID: 56599
		private int method_p2;

		// Token: 0x0400DD18 RID: 56600
		private int method_p3;

		// Token: 0x0400DD19 RID: 56601
		private int method_p4;
	}
}
