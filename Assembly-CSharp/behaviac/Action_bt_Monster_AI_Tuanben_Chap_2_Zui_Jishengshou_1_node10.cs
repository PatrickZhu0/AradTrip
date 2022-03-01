using System;

namespace behaviac
{
	// Token: 0x020037BD RID: 14269
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node10 : Action
	{
		// Token: 0x0601577B RID: 87931 RVA: 0x0067AC67 File Offset: 0x00679067
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node10()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 30000;
			this.method_p1 = 1;
		}

		// Token: 0x0601577C RID: 87932 RVA: 0x0067AC88 File Offset: 0x00679088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F12B RID: 61739
		private int method_p0;

		// Token: 0x0400F12C RID: 61740
		private int method_p1;
	}
}
