using System;

namespace behaviac
{
	// Token: 0x02002EA5 RID: 11941
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node34 : Action
	{
		// Token: 0x06014625 RID: 83493 RVA: 0x00621014 File Offset: 0x0061F414
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014626 RID: 83494 RVA: 0x0062102A File Offset: 0x0061F42A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF9E RID: 57246
		private int method_p0;
	}
}
