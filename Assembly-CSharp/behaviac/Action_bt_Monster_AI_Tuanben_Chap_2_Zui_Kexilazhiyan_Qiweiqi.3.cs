using System;

namespace behaviac
{
	// Token: 0x020037CD RID: 14285
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_node7 : Action
	{
		// Token: 0x06015798 RID: 87960 RVA: 0x0067B401 File Offset: 0x00679801
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521615;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06015799 RID: 87961 RVA: 0x0067B439 File Offset: 0x00679839
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F154 RID: 61780
		private BE_Target method_p0;

		// Token: 0x0400F155 RID: 61781
		private int method_p1;

		// Token: 0x0400F156 RID: 61782
		private int method_p2;

		// Token: 0x0400F157 RID: 61783
		private int method_p3;

		// Token: 0x0400F158 RID: 61784
		private int method_p4;
	}
}
