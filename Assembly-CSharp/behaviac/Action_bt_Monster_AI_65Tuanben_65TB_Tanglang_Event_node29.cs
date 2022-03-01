using System;

namespace behaviac
{
	// Token: 0x02002CB5 RID: 11445
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node29 : Action
	{
		// Token: 0x0601425F RID: 82527 RVA: 0x0060D036 File Offset: 0x0060B436
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
		}

		// Token: 0x06014260 RID: 82528 RVA: 0x0060D054 File Offset: 0x0060B454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC17 RID: 56343
		private BE_Target method_p0;

		// Token: 0x0400DC18 RID: 56344
		private int method_p1;
	}
}
