using System;

namespace behaviac
{
	// Token: 0x02002D41 RID: 11585
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node26 : Action
	{
		// Token: 0x06014367 RID: 82791 RVA: 0x0061258D File Offset: 0x0061098D
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521973;
		}

		// Token: 0x06014368 RID: 82792 RVA: 0x006125AE File Offset: 0x006109AE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD2D RID: 56621
		private BE_Target method_p0;

		// Token: 0x0400DD2E RID: 56622
		private int method_p1;
	}
}
