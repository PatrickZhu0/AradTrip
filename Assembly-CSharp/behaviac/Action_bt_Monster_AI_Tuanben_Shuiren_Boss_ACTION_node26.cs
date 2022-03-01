using System;

namespace behaviac
{
	// Token: 0x02003B56 RID: 15190
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node26 : Action
	{
		// Token: 0x06015E61 RID: 89697 RVA: 0x0069DA1E File Offset: 0x0069BE1E
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x06015E62 RID: 89698 RVA: 0x0069DA34 File Offset: 0x0069BE34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F730 RID: 63280
		private int method_p0;
	}
}
