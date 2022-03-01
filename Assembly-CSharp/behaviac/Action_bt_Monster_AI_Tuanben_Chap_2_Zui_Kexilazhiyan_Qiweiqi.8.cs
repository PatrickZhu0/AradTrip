using System;

namespace behaviac
{
	// Token: 0x020037D6 RID: 14294
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node8 : Action
	{
		// Token: 0x060157A8 RID: 87976 RVA: 0x0067B8A1 File Offset: 0x00679CA1
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157A9 RID: 87977 RVA: 0x0067B8D9 File Offset: 0x00679CD9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F16D RID: 61805
		private BE_Target method_p0;

		// Token: 0x0400F16E RID: 61806
		private int method_p1;

		// Token: 0x0400F16F RID: 61807
		private int method_p2;

		// Token: 0x0400F170 RID: 61808
		private int method_p3;

		// Token: 0x0400F171 RID: 61809
		private int method_p4;
	}
}
