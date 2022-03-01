using System;

namespace behaviac
{
	// Token: 0x020037D5 RID: 14293
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node7 : Action
	{
		// Token: 0x060157A6 RID: 87974 RVA: 0x0067B83D File Offset: 0x00679C3D
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521692;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157A7 RID: 87975 RVA: 0x0067B875 File Offset: 0x00679C75
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F168 RID: 61800
		private BE_Target method_p0;

		// Token: 0x0400F169 RID: 61801
		private int method_p1;

		// Token: 0x0400F16A RID: 61802
		private int method_p2;

		// Token: 0x0400F16B RID: 61803
		private int method_p3;

		// Token: 0x0400F16C RID: 61804
		private int method_p4;
	}
}
