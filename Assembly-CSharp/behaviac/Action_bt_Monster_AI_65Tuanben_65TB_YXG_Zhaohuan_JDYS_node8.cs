using System;

namespace behaviac
{
	// Token: 0x02002D47 RID: 11591
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8 : Action
	{
		// Token: 0x06014373 RID: 82803 RVA: 0x006126D7 File Offset: 0x00610AD7
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 3;
		}

		// Token: 0x06014374 RID: 82804 RVA: 0x006126F8 File Offset: 0x00610AF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD38 RID: 56632
		private int method_p0;

		// Token: 0x0400DD39 RID: 56633
		private int method_p1;
	}
}
