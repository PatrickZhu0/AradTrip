using System;

namespace behaviac
{
	// Token: 0x020037FD RID: 14333
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Sunshine_node2 : Action
	{
		// Token: 0x060157ED RID: 88045 RVA: 0x0067CD4D File Offset: 0x0067B14D
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Sunshine_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 3500;
			this.method_p1 = 0;
		}

		// Token: 0x060157EE RID: 88046 RVA: 0x0067CD70 File Offset: 0x0067B170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F1B7 RID: 61879
		private int method_p0;

		// Token: 0x0400F1B8 RID: 61880
		private int method_p1;
	}
}
