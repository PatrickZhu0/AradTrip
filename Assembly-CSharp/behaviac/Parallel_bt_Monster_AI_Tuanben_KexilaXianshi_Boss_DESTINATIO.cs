using System;

namespace behaviac
{
	// Token: 0x02003A7E RID: 14974
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node7 : Parallel
	{
		// Token: 0x06015CC4 RID: 89284 RVA: 0x0069651F File Offset: 0x0069491F
		public Parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
