using System;

namespace behaviac
{
	// Token: 0x02003347 RID: 13127
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node6 : Action
	{
		// Token: 0x06014EF1 RID: 85745 RVA: 0x0064ED3A File Offset: 0x0064D13A
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_liebing_xiashu_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnDead;
			this.method_p1 = 30020021;
		}

		// Token: 0x06014EF2 RID: 85746 RVA: 0x0064ED5B File Offset: 0x0064D15B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterOtherEvent(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7D0 RID: 59344
		private EventType method_p0;

		// Token: 0x0400E7D1 RID: 59345
		private int method_p1;
	}
}
