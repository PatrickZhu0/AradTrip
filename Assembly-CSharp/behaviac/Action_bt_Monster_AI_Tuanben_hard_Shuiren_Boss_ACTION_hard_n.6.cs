using System;

namespace behaviac
{
	// Token: 0x02003D4A RID: 15690
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node10 : Action
	{
		// Token: 0x0601622A RID: 90666 RVA: 0x006B0C06 File Offset: 0x006AF006
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601622B RID: 90667 RVA: 0x006B0C1C File Offset: 0x006AF01C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA8E RID: 64142
		private int method_p0;
	}
}
