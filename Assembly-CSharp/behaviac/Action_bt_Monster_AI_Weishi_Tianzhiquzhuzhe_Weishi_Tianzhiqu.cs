using System;

namespace behaviac
{
	// Token: 0x02003DFA RID: 15866
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node14 : Action
	{
		// Token: 0x0601637E RID: 91006 RVA: 0x006B7988 File Offset: 0x006B5D88
		public Action_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBeforeHit;
		}

		// Token: 0x0601637F RID: 91007 RVA: 0x006B799E File Offset: 0x006B5D9E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBE5 RID: 64485
		private EventType method_p0;
	}
}
