using System;

namespace behaviac
{
	// Token: 0x02003B45 RID: 15173
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node58 : Action
	{
		// Token: 0x06015E3F RID: 89663 RVA: 0x0069D4F7 File Offset: 0x0069B8F7
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node58()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06015E40 RID: 89664 RVA: 0x0069D50D File Offset: 0x0069B90D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F716 RID: 63254
		private int method_p0;
	}
}
