using System;

namespace behaviac
{
	// Token: 0x02003802 RID: 14338
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node10 : Action
	{
		// Token: 0x060157F5 RID: 88053 RVA: 0x0067CF4F File Offset: 0x0067B34F
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521657;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060157F6 RID: 88054 RVA: 0x0067CF86 File Offset: 0x0067B386
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1BC RID: 61884
		private BE_Target method_p0;

		// Token: 0x0400F1BD RID: 61885
		private int method_p1;

		// Token: 0x0400F1BE RID: 61886
		private int method_p2;

		// Token: 0x0400F1BF RID: 61887
		private int method_p3;

		// Token: 0x0400F1C0 RID: 61888
		private int method_p4;
	}
}
