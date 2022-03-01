using System;

namespace behaviac
{
	// Token: 0x02003B5D RID: 15197
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node4 : Action
	{
		// Token: 0x06015E6F RID: 89711 RVA: 0x0069DC52 File Offset: 0x0069C052
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
		}

		// Token: 0x06015E70 RID: 89712 RVA: 0x0069DC68 File Offset: 0x0069C068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F73C RID: 63292
		private int method_p0;
	}
}
