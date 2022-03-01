using System;

namespace behaviac
{
	// Token: 0x02003B5E RID: 15198
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node33 : Action
	{
		// Token: 0x06015E71 RID: 89713 RVA: 0x0069DC7C File Offset: 0x0069C07C
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x06015E72 RID: 89714 RVA: 0x0069DC92 File Offset: 0x0069C092
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F73D RID: 63293
		private int method_p0;
	}
}
