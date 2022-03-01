using System;

namespace behaviac
{
	// Token: 0x02003312 RID: 13074
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_daojishiguai_Event_node1 : Condition
	{
		// Token: 0x06014E8C RID: 85644 RVA: 0x0064CDFF File Offset: 0x0064B1FF
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_daojishiguai_Event_node1()
		{
			this.opl_p0 = EventType.OnDead;
		}

		// Token: 0x06014E8D RID: 85645 RVA: 0x0064CE10 File Offset: 0x0064B210
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E779 RID: 59257
		private EventType opl_p0;
	}
}
