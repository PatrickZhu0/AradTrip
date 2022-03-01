using System;

namespace behaviac
{
	// Token: 0x020031DE RID: 12766
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node7 : Action
	{
		// Token: 0x06014C4B RID: 85067 RVA: 0x00641B25 File Offset: 0x0063FF25
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570241;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06014C4C RID: 85068 RVA: 0x00641B5D File Offset: 0x0063FF5D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5A3 RID: 58787
		private BE_Target method_p0;

		// Token: 0x0400E5A4 RID: 58788
		private int method_p1;

		// Token: 0x0400E5A5 RID: 58789
		private int method_p2;

		// Token: 0x0400E5A6 RID: 58790
		private int method_p3;

		// Token: 0x0400E5A7 RID: 58791
		private int method_p4;
	}
}
