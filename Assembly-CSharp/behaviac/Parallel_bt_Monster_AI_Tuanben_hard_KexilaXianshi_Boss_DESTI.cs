using System;

namespace behaviac
{
	// Token: 0x02003CB0 RID: 15536
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node7 : Parallel
	{
		// Token: 0x06016106 RID: 90374 RVA: 0x006ABD07 File Offset: 0x006AA107
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_DESTINATIONSELET_hard_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
