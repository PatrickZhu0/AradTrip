using System;

namespace behaviac
{
	// Token: 0x02003483 RID: 13443
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node8 : Action
	{
		// Token: 0x0601514F RID: 86351 RVA: 0x0065A316 File Offset: 0x00658716
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnHurt;
		}

		// Token: 0x06015150 RID: 86352 RVA: 0x0065A32C File Offset: 0x0065872C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA50 RID: 59984
		private EventType method_p0;
	}
}
