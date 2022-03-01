using System;

namespace behaviac
{
	// Token: 0x02002D48 RID: 11592
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13 : Action
	{
		// Token: 0x06014375 RID: 82805 RVA: 0x0061271E File Offset: 0x00610B1E
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521971;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014376 RID: 82806 RVA: 0x00612759 File Offset: 0x00610B59
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD3A RID: 56634
		private BE_Target method_p0;

		// Token: 0x0400DD3B RID: 56635
		private int method_p1;

		// Token: 0x0400DD3C RID: 56636
		private int method_p2;

		// Token: 0x0400DD3D RID: 56637
		private int method_p3;

		// Token: 0x0400DD3E RID: 56638
		private int method_p4;
	}
}
