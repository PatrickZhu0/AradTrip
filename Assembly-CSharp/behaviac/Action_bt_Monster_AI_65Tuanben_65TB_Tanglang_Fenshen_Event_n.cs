using System;

namespace behaviac
{
	// Token: 0x02002CCD RID: 11469
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node1 : Action
	{
		// Token: 0x0601428C RID: 82572 RVA: 0x0060E308 File Offset: 0x0060C708
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 24000;
			this.method_p1 = 0;
		}

		// Token: 0x0601428D RID: 82573 RVA: 0x0060E32C File Offset: 0x0060C72C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DC3C RID: 56380
		private int method_p0;

		// Token: 0x0400DC3D RID: 56381
		private int method_p1;
	}
}
