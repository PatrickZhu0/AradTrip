using System;

namespace behaviac
{
	// Token: 0x0200359D RID: 13725
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node13 : Action
	{
		// Token: 0x0601536A RID: 86890 RVA: 0x00664B16 File Offset: 0x00662F16
		public Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528402;
			this.method_p2 = 500;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x0601536B RID: 86891 RVA: 0x00664B51 File Offset: 0x00662F51
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED32 RID: 60722
		private BE_Target method_p0;

		// Token: 0x0400ED33 RID: 60723
		private int method_p1;

		// Token: 0x0400ED34 RID: 60724
		private int method_p2;

		// Token: 0x0400ED35 RID: 60725
		private int method_p3;

		// Token: 0x0400ED36 RID: 60726
		private int method_p4;
	}
}
