using System;

namespace behaviac
{
	// Token: 0x02002CCF RID: 11471
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node5 : Action
	{
		// Token: 0x06014290 RID: 82576 RVA: 0x0060E3B9 File Offset: 0x0060C7B9
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 23500;
			this.method_p1 = 1;
		}

		// Token: 0x06014291 RID: 82577 RVA: 0x0060E3DC File Offset: 0x0060C7DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DC43 RID: 56387
		private int method_p0;

		// Token: 0x0400DC44 RID: 56388
		private int method_p1;
	}
}
