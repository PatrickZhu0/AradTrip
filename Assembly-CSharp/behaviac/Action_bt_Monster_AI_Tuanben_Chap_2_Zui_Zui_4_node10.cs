using System;

namespace behaviac
{
	// Token: 0x0200380D RID: 14349
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10 : Action
	{
		// Token: 0x06015809 RID: 88073 RVA: 0x0067D583 File Offset: 0x0067B983
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521657;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601580A RID: 88074 RVA: 0x0067D5BA File Offset: 0x0067B9BA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1CE RID: 61902
		private BE_Target method_p0;

		// Token: 0x0400F1CF RID: 61903
		private int method_p1;

		// Token: 0x0400F1D0 RID: 61904
		private int method_p2;

		// Token: 0x0400F1D1 RID: 61905
		private int method_p3;

		// Token: 0x0400F1D2 RID: 61906
		private int method_p4;
	}
}
