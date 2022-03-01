using System;

namespace behaviac
{
	// Token: 0x020037C2 RID: 14274
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5 : Action
	{
		// Token: 0x06015784 RID: 87940 RVA: 0x0067AF53 File Offset: 0x00679353
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 30000;
			this.method_p1 = 0;
		}

		// Token: 0x06015785 RID: 87941 RVA: 0x0067AF74 File Offset: 0x00679374
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F137 RID: 61751
		private int method_p0;

		// Token: 0x0400F138 RID: 61752
		private int method_p1;
	}
}
