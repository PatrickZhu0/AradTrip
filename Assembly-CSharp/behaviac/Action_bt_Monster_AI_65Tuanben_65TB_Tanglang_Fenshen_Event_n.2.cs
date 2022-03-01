using System;

namespace behaviac
{
	// Token: 0x02002CCE RID: 11470
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node2 : Action
	{
		// Token: 0x0601428E RID: 82574 RVA: 0x0060E352 File Offset: 0x0060C752
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522104;
			this.method_p2 = 3600000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601428F RID: 82575 RVA: 0x0060E38D File Offset: 0x0060C78D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC3E RID: 56382
		private BE_Target method_p0;

		// Token: 0x0400DC3F RID: 56383
		private int method_p1;

		// Token: 0x0400DC40 RID: 56384
		private int method_p2;

		// Token: 0x0400DC41 RID: 56385
		private int method_p3;

		// Token: 0x0400DC42 RID: 56386
		private int method_p4;
	}
}
