using System;

namespace behaviac
{
	// Token: 0x020037FC RID: 14332
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Sunshine_node3 : Action
	{
		// Token: 0x060157EB RID: 88043 RVA: 0x0067CCE9 File Offset: 0x0067B0E9
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Sunshine_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521658;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060157EC RID: 88044 RVA: 0x0067CD21 File Offset: 0x0067B121
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1B2 RID: 61874
		private BE_Target method_p0;

		// Token: 0x0400F1B3 RID: 61875
		private int method_p1;

		// Token: 0x0400F1B4 RID: 61876
		private int method_p2;

		// Token: 0x0400F1B5 RID: 61877
		private int method_p3;

		// Token: 0x0400F1B6 RID: 61878
		private int method_p4;
	}
}
