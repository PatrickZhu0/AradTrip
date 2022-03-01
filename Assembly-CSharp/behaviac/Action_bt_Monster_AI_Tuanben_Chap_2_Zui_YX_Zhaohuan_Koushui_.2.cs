using System;

namespace behaviac
{
	// Token: 0x020037EE RID: 14318
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node3 : Action
	{
		// Token: 0x060157D2 RID: 88018 RVA: 0x0067C652 File Offset: 0x0067AA52
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521686;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060157D3 RID: 88019 RVA: 0x0067C689 File Offset: 0x0067AA89
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F19F RID: 61855
		private BE_Target method_p0;

		// Token: 0x0400F1A0 RID: 61856
		private int method_p1;

		// Token: 0x0400F1A1 RID: 61857
		private int method_p2;

		// Token: 0x0400F1A2 RID: 61858
		private int method_p3;

		// Token: 0x0400F1A3 RID: 61859
		private int method_p4;
	}
}
