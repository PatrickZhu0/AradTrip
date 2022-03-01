using System;

namespace behaviac
{
	// Token: 0x02003734 RID: 14132
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node11 : Action
	{
		// Token: 0x06015673 RID: 87667 RVA: 0x00675329 File Offset: 0x00673729
		public Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBackHit;
		}

		// Token: 0x06015674 RID: 87668 RVA: 0x0067533F File Offset: 0x0067373F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F042 RID: 61506
		private EventType method_p0;
	}
}
