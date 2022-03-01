using System;

namespace behaviac
{
	// Token: 0x02003065 RID: 12389
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node15 : Action
	{
		// Token: 0x06014990 RID: 84368 RVA: 0x006338B1 File Offset: 0x00631CB1
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06014991 RID: 84369 RVA: 0x006338C7 File Offset: 0x00631CC7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2EF RID: 58095
		private DestinationType method_p0;
	}
}
