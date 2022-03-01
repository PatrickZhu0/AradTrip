using System;

namespace behaviac
{
	// Token: 0x02002D4E RID: 11598
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node20 : Action
	{
		// Token: 0x06014381 RID: 82817 RVA: 0x00612888 File Offset: 0x00610C88
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521971;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014382 RID: 82818 RVA: 0x006128C3 File Offset: 0x00610CC3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD48 RID: 56648
		private BE_Target method_p0;

		// Token: 0x0400DD49 RID: 56649
		private int method_p1;

		// Token: 0x0400DD4A RID: 56650
		private int method_p2;

		// Token: 0x0400DD4B RID: 56651
		private int method_p3;

		// Token: 0x0400DD4C RID: 56652
		private int method_p4;
	}
}
