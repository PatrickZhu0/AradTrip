using System;

namespace behaviac
{
	// Token: 0x02002CD0 RID: 11472
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node6 : Action
	{
		// Token: 0x06014292 RID: 82578 RVA: 0x0060E402 File Offset: 0x0060C802
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014293 RID: 82579 RVA: 0x0060E436 File Offset: 0x0060C836
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC45 RID: 56389
		private BE_Target method_p0;

		// Token: 0x0400DC46 RID: 56390
		private int method_p1;

		// Token: 0x0400DC47 RID: 56391
		private int method_p2;

		// Token: 0x0400DC48 RID: 56392
		private int method_p3;

		// Token: 0x0400DC49 RID: 56393
		private int method_p4;
	}
}
