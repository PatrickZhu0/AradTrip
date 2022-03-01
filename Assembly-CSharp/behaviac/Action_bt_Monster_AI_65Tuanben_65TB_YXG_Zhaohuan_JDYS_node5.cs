using System;

namespace behaviac
{
	// Token: 0x02002D44 RID: 11588
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5 : Action
	{
		// Token: 0x0601436D RID: 82797 RVA: 0x00612622 File Offset: 0x00610A22
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521970;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601436E RID: 82798 RVA: 0x0061265D File Offset: 0x00610A5D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD31 RID: 56625
		private BE_Target method_p0;

		// Token: 0x0400DD32 RID: 56626
		private int method_p1;

		// Token: 0x0400DD33 RID: 56627
		private int method_p2;

		// Token: 0x0400DD34 RID: 56628
		private int method_p3;

		// Token: 0x0400DD35 RID: 56629
		private int method_p4;
	}
}
