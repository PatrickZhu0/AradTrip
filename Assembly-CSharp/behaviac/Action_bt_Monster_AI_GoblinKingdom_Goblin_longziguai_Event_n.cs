using System;

namespace behaviac
{
	// Token: 0x0200334C RID: 13132
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node6 : Action
	{
		// Token: 0x06014EFA RID: 85754 RVA: 0x0064EFDD File Offset: 0x0064D3DD
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnDead;
			this.method_p1 = 30020021;
		}

		// Token: 0x06014EFB RID: 85755 RVA: 0x0064EFFE File Offset: 0x0064D3FE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterOtherEvent(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7D7 RID: 59351
		private EventType method_p0;

		// Token: 0x0400E7D8 RID: 59352
		private int method_p1;
	}
}
