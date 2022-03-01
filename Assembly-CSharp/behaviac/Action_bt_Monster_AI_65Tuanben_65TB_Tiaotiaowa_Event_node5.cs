using System;

namespace behaviac
{
	// Token: 0x02002D0D RID: 11533
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node5 : Action
	{
		// Token: 0x06014308 RID: 82696 RVA: 0x00610A43 File Offset: 0x0060EE43
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2950;
			this.method_p1 = 1;
		}

		// Token: 0x06014309 RID: 82697 RVA: 0x00610A64 File Offset: 0x0060EE64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DCB3 RID: 56499
		private int method_p0;

		// Token: 0x0400DCB4 RID: 56500
		private int method_p1;
	}
}
