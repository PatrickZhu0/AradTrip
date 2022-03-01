using System;

namespace behaviac
{
	// Token: 0x02003304 RID: 13060
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node10 : Action
	{
		// Token: 0x06014E72 RID: 85618 RVA: 0x0064C3AF File Offset: 0x0064A7AF
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x06014E73 RID: 85619 RVA: 0x0064C3C5 File Offset: 0x0064A7C5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E761 RID: 59233
		private DestinationType method_p0;
	}
}
