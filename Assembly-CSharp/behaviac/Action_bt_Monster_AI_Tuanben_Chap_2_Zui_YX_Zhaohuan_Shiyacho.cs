using System;

namespace behaviac
{
	// Token: 0x020037F2 RID: 14322
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2 : Action
	{
		// Token: 0x060157D9 RID: 88025 RVA: 0x0067C849 File Offset: 0x0067AC49
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 15000;
			this.method_p1 = 0;
		}

		// Token: 0x060157DA RID: 88026 RVA: 0x0067C86C File Offset: 0x0067AC6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F1A4 RID: 61860
		private int method_p0;

		// Token: 0x0400F1A5 RID: 61861
		private int method_p1;
	}
}
