using System;

namespace behaviac
{
	// Token: 0x02002EA9 RID: 11945
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node37 : Action
	{
		// Token: 0x0601462D RID: 83501 RVA: 0x006210F3 File Offset: 0x0061F4F3
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601462E RID: 83502 RVA: 0x00621109 File Offset: 0x0061F509
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFA4 RID: 57252
		private int method_p0;
	}
}
