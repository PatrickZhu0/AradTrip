using System;

namespace behaviac
{
	// Token: 0x02002D4B RID: 11595
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17 : Action
	{
		// Token: 0x0601437B RID: 82811 RVA: 0x006127D3 File Offset: 0x00610BD3
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521970;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601437C RID: 82812 RVA: 0x0061280E File Offset: 0x00610C0E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD41 RID: 56641
		private BE_Target method_p0;

		// Token: 0x0400DD42 RID: 56642
		private int method_p1;

		// Token: 0x0400DD43 RID: 56643
		private int method_p2;

		// Token: 0x0400DD44 RID: 56644
		private int method_p3;

		// Token: 0x0400DD45 RID: 56645
		private int method_p4;
	}
}
