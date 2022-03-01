using System;

namespace behaviac
{
	// Token: 0x020030C4 RID: 12484
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node1 : Action
	{
		// Token: 0x06014A43 RID: 84547 RVA: 0x006373D4 File Offset: 0x006357D4
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06014A44 RID: 84548 RVA: 0x006373EA File Offset: 0x006357EA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B0 RID: 58288
		private EventType method_p0;
	}
}
