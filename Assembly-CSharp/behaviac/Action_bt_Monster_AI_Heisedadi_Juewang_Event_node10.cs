using System;

namespace behaviac
{
	// Token: 0x02003487 RID: 13447
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node10 : Action
	{
		// Token: 0x06015157 RID: 86359 RVA: 0x0065A41E File Offset: 0x0065881E
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015158 RID: 86360 RVA: 0x0065A434 File Offset: 0x00658834
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_UnRegistEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA57 RID: 59991
		private EventType method_p0;
	}
}
