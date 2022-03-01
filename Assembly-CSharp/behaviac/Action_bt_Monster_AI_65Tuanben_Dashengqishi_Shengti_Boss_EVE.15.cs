using System;

namespace behaviac
{
	// Token: 0x02002EA4 RID: 11940
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node33 : Action
	{
		// Token: 0x06014623 RID: 83491 RVA: 0x00620FEA File Offset: 0x0061F3EA
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014624 RID: 83492 RVA: 0x00621000 File Offset: 0x0061F400
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF9D RID: 57245
		private int method_p0;
	}
}
