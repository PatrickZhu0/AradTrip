using System;

namespace behaviac
{
	// Token: 0x02003D50 RID: 15696
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node26 : Action
	{
		// Token: 0x06016236 RID: 90678 RVA: 0x006B0E0E File Offset: 0x006AF20E
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x06016237 RID: 90679 RVA: 0x006B0E24 File Offset: 0x006AF224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA99 RID: 64153
		private int method_p0;
	}
}
