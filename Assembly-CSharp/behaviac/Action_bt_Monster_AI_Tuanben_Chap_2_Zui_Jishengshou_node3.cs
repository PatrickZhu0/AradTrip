using System;

namespace behaviac
{
	// Token: 0x020037B9 RID: 14265
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3 : Action
	{
		// Token: 0x06015774 RID: 87924 RVA: 0x0067A9C2 File Offset: 0x00678DC2
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 3500;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015775 RID: 87925 RVA: 0x0067A9FA File Offset: 0x00678DFA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F121 RID: 61729
		private BE_Target method_p0;

		// Token: 0x0400F122 RID: 61730
		private int method_p1;

		// Token: 0x0400F123 RID: 61731
		private int method_p2;

		// Token: 0x0400F124 RID: 61732
		private int method_p3;

		// Token: 0x0400F125 RID: 61733
		private int method_p4;
	}
}
