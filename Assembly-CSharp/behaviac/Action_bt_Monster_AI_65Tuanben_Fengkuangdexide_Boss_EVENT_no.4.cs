using System;

namespace behaviac
{
	// Token: 0x02002EF5 RID: 12021
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node23 : Action
	{
		// Token: 0x060146C2 RID: 83650 RVA: 0x00624B62 File Offset: 0x00622F62
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060146C3 RID: 83651 RVA: 0x00624B78 File Offset: 0x00622F78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E037 RID: 57399
		private int method_p0;
	}
}
