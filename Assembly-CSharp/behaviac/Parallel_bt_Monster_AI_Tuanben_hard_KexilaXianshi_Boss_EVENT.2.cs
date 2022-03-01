using System;

namespace behaviac
{
	// Token: 0x02003CB9 RID: 15545
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node33 : Parallel
	{
		// Token: 0x06016115 RID: 90389 RVA: 0x006AC0EF File Offset: 0x006AA4EF
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node33()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
