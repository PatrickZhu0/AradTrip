using System;

namespace behaviac
{
	// Token: 0x020037C5 RID: 14277
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2 : Action
	{
		// Token: 0x0601578A RID: 87946 RVA: 0x0067B068 File Offset: 0x00679468
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521621;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601578B RID: 87947 RVA: 0x0067B09F File Offset: 0x0067949F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F143 RID: 61763
		private BE_Target method_p0;

		// Token: 0x0400F144 RID: 61764
		private int method_p1;

		// Token: 0x0400F145 RID: 61765
		private int method_p2;

		// Token: 0x0400F146 RID: 61766
		private int method_p3;

		// Token: 0x0400F147 RID: 61767
		private int method_p4;
	}
}
