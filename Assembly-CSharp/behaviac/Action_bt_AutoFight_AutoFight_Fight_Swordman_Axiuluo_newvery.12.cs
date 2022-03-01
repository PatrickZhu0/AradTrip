using System;

namespace behaviac
{
	// Token: 0x02002238 RID: 8760
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node9 : Action
	{
		// Token: 0x06012DF9 RID: 77305 RVA: 0x0059018B File Offset: 0x0058E58B
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBeforeOtherHit;
		}

		// Token: 0x06012DFA RID: 77306 RVA: 0x005901A1 File Offset: 0x0058E5A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7F8 RID: 51192
		private EventType method_p0;
	}
}
