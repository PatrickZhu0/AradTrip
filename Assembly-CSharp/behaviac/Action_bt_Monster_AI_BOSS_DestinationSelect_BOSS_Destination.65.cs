using System;

namespace behaviac
{
	// Token: 0x0200306E RID: 12398
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node27 : Action
	{
		// Token: 0x060149A2 RID: 84386 RVA: 0x00633B75 File Offset: 0x00631F75
		public Action_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x060149A3 RID: 84387 RVA: 0x00633B8B File Offset: 0x00631F8B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E301 RID: 58113
		private DestinationType method_p0;
	}
}
