using System;

namespace behaviac
{
	// Token: 0x02002EF6 RID: 12022
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node24 : Action
	{
		// Token: 0x060146C4 RID: 83652 RVA: 0x00624B8C File Offset: 0x00622F8C
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060146C5 RID: 83653 RVA: 0x00624BA2 File Offset: 0x00622FA2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E038 RID: 57400
		private int method_p0;
	}
}
