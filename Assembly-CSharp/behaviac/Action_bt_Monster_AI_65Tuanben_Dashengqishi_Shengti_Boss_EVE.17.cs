using System;

namespace behaviac
{
	// Token: 0x02002EA7 RID: 11943
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node260 : Action
	{
		// Token: 0x06014629 RID: 83497 RVA: 0x0062109F File Offset: 0x0061F49F
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node260()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601462A RID: 83498 RVA: 0x006210B5 File Offset: 0x0061F4B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFA2 RID: 57250
		private int method_p0;
	}
}
