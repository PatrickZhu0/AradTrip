using System;

namespace behaviac
{
	// Token: 0x02003B49 RID: 15177
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node61 : Action
	{
		// Token: 0x06015E47 RID: 89671 RVA: 0x0069D5E3 File Offset: 0x0069B9E3
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node61()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015E48 RID: 89672 RVA: 0x0069D5F9 File Offset: 0x0069B9F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F71A RID: 63258
		private int method_p0;
	}
}
