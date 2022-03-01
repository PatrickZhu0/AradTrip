using System;

namespace behaviac
{
	// Token: 0x020037F7 RID: 14327
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_Hard_node2 : Action
	{
		// Token: 0x060157E2 RID: 88034 RVA: 0x0067CA99 File Offset: 0x0067AE99
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_Hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 15000;
			this.method_p1 = 0;
		}

		// Token: 0x060157E3 RID: 88035 RVA: 0x0067CABC File Offset: 0x0067AEBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F1AB RID: 61867
		private int method_p0;

		// Token: 0x0400F1AC RID: 61868
		private int method_p1;
	}
}
