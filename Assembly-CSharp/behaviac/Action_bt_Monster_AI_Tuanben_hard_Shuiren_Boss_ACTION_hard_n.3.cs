using System;

namespace behaviac
{
	// Token: 0x02003D43 RID: 15683
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node61 : Action
	{
		// Token: 0x0601621C RID: 90652 RVA: 0x006B09D3 File Offset: 0x006AEDD3
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node61()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x0601621D RID: 90653 RVA: 0x006B09E9 File Offset: 0x006AEDE9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA83 RID: 64131
		private int method_p0;
	}
}
