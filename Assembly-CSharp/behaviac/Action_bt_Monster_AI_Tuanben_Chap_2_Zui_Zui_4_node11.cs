using System;

namespace behaviac
{
	// Token: 0x02003812 RID: 14354
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11 : Action
	{
		// Token: 0x06015813 RID: 88083 RVA: 0x0067D751 File Offset: 0x0067BB51
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521657;
		}

		// Token: 0x06015814 RID: 88084 RVA: 0x0067D772 File Offset: 0x0067BB72
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1D9 RID: 61913
		private BE_Target method_p0;

		// Token: 0x0400F1DA RID: 61914
		private int method_p1;
	}
}
