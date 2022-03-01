using System;

namespace behaviac
{
	// Token: 0x020037D2 RID: 14290
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node2 : Action
	{
		// Token: 0x060157A0 RID: 87968 RVA: 0x0067B740 File Offset: 0x00679B40
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521691;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157A1 RID: 87969 RVA: 0x0067B778 File Offset: 0x00679B78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F15E RID: 61790
		private BE_Target method_p0;

		// Token: 0x0400F15F RID: 61791
		private int method_p1;

		// Token: 0x0400F160 RID: 61792
		private int method_p2;

		// Token: 0x0400F161 RID: 61793
		private int method_p3;

		// Token: 0x0400F162 RID: 61794
		private int method_p4;
	}
}
