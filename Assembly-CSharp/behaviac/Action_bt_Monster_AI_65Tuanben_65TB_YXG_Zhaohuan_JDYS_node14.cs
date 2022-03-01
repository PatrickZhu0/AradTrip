using System;

namespace behaviac
{
	// Token: 0x02002D40 RID: 11584
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14 : Action
	{
		// Token: 0x06014365 RID: 82789 RVA: 0x00612526 File Offset: 0x00610926
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521971;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014366 RID: 82790 RVA: 0x00612561 File Offset: 0x00610961
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD28 RID: 56616
		private BE_Target method_p0;

		// Token: 0x0400DD29 RID: 56617
		private int method_p1;

		// Token: 0x0400DD2A RID: 56618
		private int method_p2;

		// Token: 0x0400DD2B RID: 56619
		private int method_p3;

		// Token: 0x0400DD2C RID: 56620
		private int method_p4;
	}
}
