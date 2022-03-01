using System;

namespace behaviac
{
	// Token: 0x02002EF3 RID: 12019
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node53 : Action
	{
		// Token: 0x060146BE RID: 83646 RVA: 0x00624AEE File Offset: 0x00622EEE
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060146BF RID: 83647 RVA: 0x00624B04 File Offset: 0x00622F04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E035 RID: 57397
		private int method_p0;
	}
}
