using System;

namespace behaviac
{
	// Token: 0x02003D58 RID: 15704
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node33 : Action
	{
		// Token: 0x06016246 RID: 90694 RVA: 0x006B106C File Offset: 0x006AF46C
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x06016247 RID: 90695 RVA: 0x006B1082 File Offset: 0x006AF482
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAA6 RID: 64166
		private int method_p0;
	}
}
