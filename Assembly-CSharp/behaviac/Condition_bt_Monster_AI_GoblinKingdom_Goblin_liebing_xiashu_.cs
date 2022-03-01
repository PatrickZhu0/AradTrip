using System;

namespace behaviac
{
	// Token: 0x02003348 RID: 13128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node1 : Condition
	{
		// Token: 0x06014EF3 RID: 85747 RVA: 0x0064ED75 File Offset: 0x0064D175
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node1()
		{
			this.opl_p0 = EventType.OnDead;
		}

		// Token: 0x06014EF4 RID: 85748 RVA: 0x0064ED84 File Offset: 0x0064D184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7D2 RID: 59346
		private EventType opl_p0;
	}
}
