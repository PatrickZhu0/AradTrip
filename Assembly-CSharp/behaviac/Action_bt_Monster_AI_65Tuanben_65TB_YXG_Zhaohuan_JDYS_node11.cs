using System;

namespace behaviac
{
	// Token: 0x02002D3C RID: 11580
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11 : Action
	{
		// Token: 0x0601435D RID: 82781 RVA: 0x0061242A File Offset: 0x0061082A
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521970;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601435E RID: 82782 RVA: 0x00612465 File Offset: 0x00610865
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD1F RID: 56607
		private BE_Target method_p0;

		// Token: 0x0400DD20 RID: 56608
		private int method_p1;

		// Token: 0x0400DD21 RID: 56609
		private int method_p2;

		// Token: 0x0400DD22 RID: 56610
		private int method_p3;

		// Token: 0x0400DD23 RID: 56611
		private int method_p4;
	}
}
