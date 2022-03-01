using System;

namespace behaviac
{
	// Token: 0x02002EEF RID: 12015
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node0 : Parallel
	{
		// Token: 0x060146B7 RID: 83639 RVA: 0x00624A2B File Offset: 0x00622E2B
		public Parallel_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
