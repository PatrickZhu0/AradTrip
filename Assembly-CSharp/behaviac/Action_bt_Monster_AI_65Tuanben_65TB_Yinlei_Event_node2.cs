using System;

namespace behaviac
{
	// Token: 0x02002D32 RID: 11570
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2 : Action
	{
		// Token: 0x0601434C RID: 82764 RVA: 0x0061207E File Offset: 0x0061047E
		public Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521967;
			this.method_p2 = 3000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601434D RID: 82765 RVA: 0x006120B9 File Offset: 0x006104B9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD0E RID: 56590
		private BE_Target method_p0;

		// Token: 0x0400DD0F RID: 56591
		private int method_p1;

		// Token: 0x0400DD10 RID: 56592
		private int method_p2;

		// Token: 0x0400DD11 RID: 56593
		private int method_p3;

		// Token: 0x0400DD12 RID: 56594
		private int method_p4;
	}
}
