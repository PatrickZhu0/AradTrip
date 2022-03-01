using System;

namespace behaviac
{
	// Token: 0x02002D34 RID: 11572
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node0 : Action
	{
		// Token: 0x0601434F RID: 82767 RVA: 0x006121B0 File Offset: 0x006105B0
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Weiming_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 150;
			this.method_p1 = 0;
		}

		// Token: 0x06014350 RID: 82768 RVA: 0x006121D4 File Offset: 0x006105D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD13 RID: 56595
		private int method_p0;

		// Token: 0x0400DD14 RID: 56596
		private int method_p1;
	}
}
