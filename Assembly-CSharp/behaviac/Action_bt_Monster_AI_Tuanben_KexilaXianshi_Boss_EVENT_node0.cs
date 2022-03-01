using System;

namespace behaviac
{
	// Token: 0x02003A86 RID: 14982
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node0 : Action
	{
		// Token: 0x06015CD1 RID: 89297 RVA: 0x006968DD File Offset: 0x00694CDD
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015CD2 RID: 89298 RVA: 0x006968F3 File Offset: 0x00694CF3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEventNew(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F60A RID: 62986
		private EventType method_p0;
	}
}
