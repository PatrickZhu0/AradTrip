using System;

namespace behaviac
{
	// Token: 0x020037CA RID: 14282
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_node2 : Action
	{
		// Token: 0x06015792 RID: 87954 RVA: 0x0067B304 File Offset: 0x00679704
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521613;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06015793 RID: 87955 RVA: 0x0067B33C File Offset: 0x0067973C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F14A RID: 61770
		private BE_Target method_p0;

		// Token: 0x0400F14B RID: 61771
		private int method_p1;

		// Token: 0x0400F14C RID: 61772
		private int method_p2;

		// Token: 0x0400F14D RID: 61773
		private int method_p3;

		// Token: 0x0400F14E RID: 61774
		private int method_p4;
	}
}
