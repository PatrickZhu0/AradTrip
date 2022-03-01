using System;

namespace behaviac
{
	// Token: 0x02003810 RID: 14352
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9 : Action
	{
		// Token: 0x0601580F RID: 88079 RVA: 0x0067D6CC File Offset: 0x0067BACC
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node9()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 0;
		}

		// Token: 0x06015810 RID: 88080 RVA: 0x0067D6F0 File Offset: 0x0067BAF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F1D5 RID: 61909
		private int method_p0;

		// Token: 0x0400F1D6 RID: 61910
		private int method_p1;
	}
}
