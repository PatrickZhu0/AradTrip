using System;

namespace behaviac
{
	// Token: 0x02002D95 RID: 11669
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node43 : Action
	{
		// Token: 0x0601440B RID: 82955 RVA: 0x00615A3A File Offset: 0x00613E3A
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node43()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x0601440C RID: 82956 RVA: 0x00615A57 File Offset: 0x00613E57
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDD4 RID: 56788
		private int method_p0;

		// Token: 0x0400DDD5 RID: 56789
		private int method_p1;
	}
}
