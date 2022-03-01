using System;

namespace behaviac
{
	// Token: 0x02002D51 RID: 11601
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node34 : Action
	{
		// Token: 0x06014387 RID: 82823 RVA: 0x00612972 File Offset: 0x00610D72
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521974;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014388 RID: 82824 RVA: 0x006129A9 File Offset: 0x00610DA9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD51 RID: 56657
		private BE_Target method_p0;

		// Token: 0x0400DD52 RID: 56658
		private int method_p1;

		// Token: 0x0400DD53 RID: 56659
		private int method_p2;

		// Token: 0x0400DD54 RID: 56660
		private int method_p3;

		// Token: 0x0400DD55 RID: 56661
		private int method_p4;
	}
}
