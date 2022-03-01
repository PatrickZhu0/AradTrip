using System;

namespace behaviac
{
	// Token: 0x020030AF RID: 12463
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node1 : Action
	{
		// Token: 0x06014A20 RID: 84512 RVA: 0x0063693C File Offset: 0x00634D3C
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06014A21 RID: 84513 RVA: 0x00636952 File Offset: 0x00634D52
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E380 RID: 58240
		private EventType method_p0;
	}
}
