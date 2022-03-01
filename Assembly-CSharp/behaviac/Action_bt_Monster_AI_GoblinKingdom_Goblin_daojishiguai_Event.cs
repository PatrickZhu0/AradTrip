using System;

namespace behaviac
{
	// Token: 0x02003311 RID: 13073
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_daojishiguai_Event_node6 : Action
	{
		// Token: 0x06014E8A RID: 85642 RVA: 0x0064CDC4 File Offset: 0x0064B1C4
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_daojishiguai_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnDead;
			this.method_p1 = 30330011;
		}

		// Token: 0x06014E8B RID: 85643 RVA: 0x0064CDE5 File Offset: 0x0064B1E5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterOtherEvent(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E777 RID: 59255
		private EventType method_p0;

		// Token: 0x0400E778 RID: 59256
		private int method_p1;
	}
}
