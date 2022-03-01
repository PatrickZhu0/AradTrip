using System;

namespace behaviac
{
	// Token: 0x020037D3 RID: 14291
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node3 : Action
	{
		// Token: 0x060157A2 RID: 87970 RVA: 0x0067B7A4 File Offset: 0x00679BA4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157A3 RID: 87971 RVA: 0x0067B7DC File Offset: 0x00679BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F163 RID: 61795
		private BE_Target method_p0;

		// Token: 0x0400F164 RID: 61796
		private int method_p1;

		// Token: 0x0400F165 RID: 61797
		private int method_p2;

		// Token: 0x0400F166 RID: 61798
		private int method_p3;

		// Token: 0x0400F167 RID: 61799
		private int method_p4;
	}
}
