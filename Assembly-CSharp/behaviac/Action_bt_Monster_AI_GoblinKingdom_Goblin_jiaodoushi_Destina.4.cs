using System;

namespace behaviac
{
	// Token: 0x0200333E RID: 13118
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node8 : Action
	{
		// Token: 0x06014EE0 RID: 85728 RVA: 0x0064E41F File Offset: 0x0064C81F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06014EE1 RID: 85729 RVA: 0x0064E435 File Offset: 0x0064C835
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C5 RID: 59333
		private DestinationType method_p0;
	}
}
