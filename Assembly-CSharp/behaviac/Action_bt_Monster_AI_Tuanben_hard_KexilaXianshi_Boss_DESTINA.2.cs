using System;

namespace behaviac
{
	// Token: 0x02003CB5 RID: 15541
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node0 : Action
	{
		// Token: 0x0601610F RID: 90383 RVA: 0x006ABE93 File Offset: 0x006AA293
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06016110 RID: 90384 RVA: 0x006ABEA9 File Offset: 0x006AA2A9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9B7 RID: 63927
		private DestinationType method_p0;
	}
}
