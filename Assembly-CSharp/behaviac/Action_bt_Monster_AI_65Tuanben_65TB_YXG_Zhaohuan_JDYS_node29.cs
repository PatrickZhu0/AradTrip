using System;

namespace behaviac
{
	// Token: 0x02002D4C RID: 11596
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node29 : Action
	{
		// Token: 0x0601437D RID: 82813 RVA: 0x0061283A File Offset: 0x00610C3A
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521973;
		}

		// Token: 0x0601437E RID: 82814 RVA: 0x0061285B File Offset: 0x00610C5B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD46 RID: 56646
		private BE_Target method_p0;

		// Token: 0x0400DD47 RID: 56647
		private int method_p1;
	}
}
