using System;

namespace behaviac
{
	// Token: 0x02003120 RID: 12576
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node25 : Action
	{
		// Token: 0x06014AE5 RID: 84709 RVA: 0x0063A60E File Offset: 0x00638A0E
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06014AE6 RID: 84710 RVA: 0x0063A630 File Offset: 0x00638A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E44F RID: 58447
		private int method_p0;

		// Token: 0x0400E450 RID: 58448
		private int method_p1;
	}
}
