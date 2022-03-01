using System;

namespace behaviac
{
	// Token: 0x02003B57 RID: 15191
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node32 : Action
	{
		// Token: 0x06015E63 RID: 89699 RVA: 0x0069DA48 File Offset: 0x0069BE48
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node32()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015E64 RID: 89700 RVA: 0x0069DA5E File Offset: 0x0069BE5E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F731 RID: 63281
		private int method_p0;
	}
}
