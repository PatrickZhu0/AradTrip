using System;

namespace behaviac
{
	// Token: 0x0200334D RID: 13133
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node1 : Condition
	{
		// Token: 0x06014EFC RID: 85756 RVA: 0x0064F018 File Offset: 0x0064D418
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node1()
		{
			this.opl_p0 = EventType.OnDead;
		}

		// Token: 0x06014EFD RID: 85757 RVA: 0x0064F028 File Offset: 0x0064D428
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7D9 RID: 59353
		private EventType opl_p0;
	}
}
