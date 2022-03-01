using System;

namespace behaviac
{
	// Token: 0x02003716 RID: 14102
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node11 : Action
	{
		// Token: 0x06015639 RID: 87609 RVA: 0x00674173 File Offset: 0x00672573
		public Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBackHit;
		}

		// Token: 0x0601563A RID: 87610 RVA: 0x00674189 File Offset: 0x00672589
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F005 RID: 61445
		private EventType method_p0;
	}
}
