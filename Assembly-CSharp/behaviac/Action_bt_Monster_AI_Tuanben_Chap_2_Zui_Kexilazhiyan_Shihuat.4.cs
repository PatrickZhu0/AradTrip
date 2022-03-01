using System;

namespace behaviac
{
	// Token: 0x020037DE RID: 14302
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_Hard_node3 : Action
	{
		// Token: 0x060157B6 RID: 87990 RVA: 0x0067BE27 File Offset: 0x0067A227
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Shihuatai_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157B7 RID: 87991 RVA: 0x0067BE5F File Offset: 0x0067A25F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F17F RID: 61823
		private BE_Target method_p0;

		// Token: 0x0400F180 RID: 61824
		private int method_p1;

		// Token: 0x0400F181 RID: 61825
		private int method_p2;

		// Token: 0x0400F182 RID: 61826
		private int method_p3;

		// Token: 0x0400F183 RID: 61827
		private int method_p4;
	}
}
