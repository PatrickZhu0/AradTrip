using System;

namespace behaviac
{
	// Token: 0x0200382B RID: 14379
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_node1 : Action
	{
		// Token: 0x06015841 RID: 88129 RVA: 0x0067E644 File Offset: 0x0067CA44
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 180000;
			this.method_p1 = 0;
		}

		// Token: 0x06015842 RID: 88130 RVA: 0x0067E668 File Offset: 0x0067CA68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F203 RID: 61955
		private int method_p0;

		// Token: 0x0400F204 RID: 61956
		private int method_p1;
	}
}
