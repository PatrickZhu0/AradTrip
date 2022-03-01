using System;

namespace behaviac
{
	// Token: 0x02003CB8 RID: 15544
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node0 : Action
	{
		// Token: 0x06016113 RID: 90387 RVA: 0x006AC0C5 File Offset: 0x006AA4C5
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06016114 RID: 90388 RVA: 0x006AC0DB File Offset: 0x006AA4DB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEventNew(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9B8 RID: 63928
		private EventType method_p0;
	}
}
