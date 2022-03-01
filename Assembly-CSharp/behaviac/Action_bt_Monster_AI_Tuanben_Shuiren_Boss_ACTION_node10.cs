using System;

namespace behaviac
{
	// Token: 0x02003B50 RID: 15184
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node10 : Action
	{
		// Token: 0x06015E55 RID: 89685 RVA: 0x0069D816 File Offset: 0x0069BC16
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015E56 RID: 89686 RVA: 0x0069D82C File Offset: 0x0069BC2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F725 RID: 63269
		private int method_p0;
	}
}
