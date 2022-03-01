using System;

namespace behaviac
{
	// Token: 0x02002D3F RID: 11583
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node1 : Action
	{
		// Token: 0x06014363 RID: 82787 RVA: 0x006124DF File Offset: 0x006108DF
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 1;
		}

		// Token: 0x06014364 RID: 82788 RVA: 0x00612500 File Offset: 0x00610900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD26 RID: 56614
		private int method_p0;

		// Token: 0x0400DD27 RID: 56615
		private int method_p1;
	}
}
