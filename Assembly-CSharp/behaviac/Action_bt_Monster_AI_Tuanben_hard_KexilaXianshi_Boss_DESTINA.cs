using System;

namespace behaviac
{
	// Token: 0x02003CB3 RID: 15539
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node10 : Action
	{
		// Token: 0x0601610B RID: 90379 RVA: 0x006ABE08 File Offset: 0x006AA208
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x0601610C RID: 90380 RVA: 0x006ABE1E File Offset: 0x006AA21E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9B3 RID: 63923
		private DestinationType method_p0;
	}
}
