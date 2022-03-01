using System;

namespace behaviac
{
	// Token: 0x02003D57 RID: 15703
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node4 : Action
	{
		// Token: 0x06016244 RID: 90692 RVA: 0x006B1042 File Offset: 0x006AF442
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
		}

		// Token: 0x06016245 RID: 90693 RVA: 0x006B1058 File Offset: 0x006AF458
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAA5 RID: 64165
		private int method_p0;
	}
}
