using System;

namespace behaviac
{
	// Token: 0x0200332E RID: 13102
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2 : Action
	{
		// Token: 0x06014EC1 RID: 85697 RVA: 0x0064DD63 File Offset: 0x0064C163
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06014EC2 RID: 85698 RVA: 0x0064DD79 File Offset: 0x0064C179
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7A7 RID: 59303
		private DestinationType method_p0;
	}
}
