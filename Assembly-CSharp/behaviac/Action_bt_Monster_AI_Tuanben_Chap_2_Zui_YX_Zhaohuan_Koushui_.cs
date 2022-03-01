using System;

namespace behaviac
{
	// Token: 0x020037ED RID: 14317
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2 : Action
	{
		// Token: 0x060157D0 RID: 88016 RVA: 0x0067C609 File Offset: 0x0067AA09
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 6000;
			this.method_p1 = 0;
		}

		// Token: 0x060157D1 RID: 88017 RVA: 0x0067C62C File Offset: 0x0067AA2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F19D RID: 61853
		private int method_p0;

		// Token: 0x0400F19E RID: 61854
		private int method_p1;
	}
}
