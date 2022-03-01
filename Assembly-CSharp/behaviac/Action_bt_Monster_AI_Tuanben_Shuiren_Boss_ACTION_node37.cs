using System;

namespace behaviac
{
	// Token: 0x02003B41 RID: 15169
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node37 : Action
	{
		// Token: 0x06015E37 RID: 89655 RVA: 0x0069D40B File Offset: 0x0069B80B
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015E38 RID: 89656 RVA: 0x0069D421 File Offset: 0x0069B821
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F712 RID: 63250
		private int method_p0;
	}
}
