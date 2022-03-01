using System;

namespace behaviac
{
	// Token: 0x02003805 RID: 14341
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node9 : Action
	{
		// Token: 0x060157FB RID: 88059 RVA: 0x0067D098 File Offset: 0x0067B498
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node9()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 0;
		}

		// Token: 0x060157FC RID: 88060 RVA: 0x0067D0BC File Offset: 0x0067B4BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F1C3 RID: 61891
		private int method_p0;

		// Token: 0x0400F1C4 RID: 61892
		private int method_p1;
	}
}
