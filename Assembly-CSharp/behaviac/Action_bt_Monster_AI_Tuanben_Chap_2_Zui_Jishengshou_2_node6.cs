using System;

namespace behaviac
{
	// Token: 0x020037C4 RID: 14276
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node6 : Action
	{
		// Token: 0x06015788 RID: 87944 RVA: 0x0067B001 File Offset: 0x00679401
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521620;
			this.method_p2 = 3100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015789 RID: 87945 RVA: 0x0067B03C File Offset: 0x0067943C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F13E RID: 61758
		private BE_Target method_p0;

		// Token: 0x0400F13F RID: 61759
		private int method_p1;

		// Token: 0x0400F140 RID: 61760
		private int method_p2;

		// Token: 0x0400F141 RID: 61761
		private int method_p3;

		// Token: 0x0400F142 RID: 61762
		private int method_p4;
	}
}
