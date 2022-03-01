using System;

namespace behaviac
{
	// Token: 0x0200330A RID: 13066
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node5 : Action
	{
		// Token: 0x06014E7D RID: 85629 RVA: 0x0064CA6F File Offset: 0x0064AE6F
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06014E7E RID: 85630 RVA: 0x0064CA85 File Offset: 0x0064AE85
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E769 RID: 59241
		private EventType method_p0;
	}
}
