using System;

namespace behaviac
{
	// Token: 0x02002CB8 RID: 11448
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node17 : Action
	{
		// Token: 0x06014265 RID: 82533 RVA: 0x0060D10A File Offset: 0x0060B50A
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522109;
		}

		// Token: 0x06014266 RID: 82534 RVA: 0x0060D12B File Offset: 0x0060B52B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC1E RID: 56350
		private BE_Target method_p0;

		// Token: 0x0400DC1F RID: 56351
		private int method_p1;
	}
}
