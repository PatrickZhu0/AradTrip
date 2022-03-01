using System;

namespace behaviac
{
	// Token: 0x02003D3B RID: 15675
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node37 : Action
	{
		// Token: 0x0601620C RID: 90636 RVA: 0x006B07FB File Offset: 0x006AEBFB
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x0601620D RID: 90637 RVA: 0x006B0811 File Offset: 0x006AEC11
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA7B RID: 64123
		private int method_p0;
	}
}
