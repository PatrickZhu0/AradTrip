using System;

namespace behaviac
{
	// Token: 0x02003CDD RID: 15581
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node97 : Parallel
	{
		// Token: 0x0601615C RID: 90460 RVA: 0x006ACB61 File Offset: 0x006AAF61
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node97()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
