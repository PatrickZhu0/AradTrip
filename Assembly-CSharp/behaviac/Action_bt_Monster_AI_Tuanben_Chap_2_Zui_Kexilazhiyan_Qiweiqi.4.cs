using System;

namespace behaviac
{
	// Token: 0x020037CE RID: 14286
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_node8 : Action
	{
		// Token: 0x0601579A RID: 87962 RVA: 0x0067B465 File Offset: 0x00679865
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x0601579B RID: 87963 RVA: 0x0067B49D File Offset: 0x0067989D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F159 RID: 61785
		private BE_Target method_p0;

		// Token: 0x0400F15A RID: 61786
		private int method_p1;

		// Token: 0x0400F15B RID: 61787
		private int method_p2;

		// Token: 0x0400F15C RID: 61788
		private int method_p3;

		// Token: 0x0400F15D RID: 61789
		private int method_p4;
	}
}
