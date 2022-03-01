using System;

namespace behaviac
{
	// Token: 0x02002D15 RID: 11541
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node18 : Action
	{
		// Token: 0x06014318 RID: 82712 RVA: 0x00610CF6 File Offset: 0x0060F0F6
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node18()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 200;
			this.method_p1 = 2;
		}

		// Token: 0x06014319 RID: 82713 RVA: 0x00610D18 File Offset: 0x0060F118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DCCB RID: 56523
		private int method_p0;

		// Token: 0x0400DCCC RID: 56524
		private int method_p1;
	}
}
