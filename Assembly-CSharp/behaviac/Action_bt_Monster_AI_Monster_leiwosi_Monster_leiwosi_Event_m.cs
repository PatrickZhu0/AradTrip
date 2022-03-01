using System;

namespace behaviac
{
	// Token: 0x020036BC RID: 14012
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3 : Action
	{
		// Token: 0x06015591 RID: 87441 RVA: 0x00670B49 File Offset: 0x0066EF49
		public Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015592 RID: 87442 RVA: 0x00670B5F File Offset: 0x0066EF5F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF64 RID: 61284
		private EventType method_p0;
	}
}
