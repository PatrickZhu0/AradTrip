using System;

namespace behaviac
{
	// Token: 0x02002D50 RID: 11600
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node33 : Action
	{
		// Token: 0x06014385 RID: 82821 RVA: 0x0061292A File Offset: 0x00610D2A
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node33()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3000;
			this.method_p1 = 4;
		}

		// Token: 0x06014386 RID: 82822 RVA: 0x0061294C File Offset: 0x00610D4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD4F RID: 56655
		private int method_p0;

		// Token: 0x0400DD50 RID: 56656
		private int method_p1;
	}
}
