using System;

namespace behaviac
{
	// Token: 0x02002C3C RID: 11324
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node5 : Parallel
	{
		// Token: 0x06014175 RID: 82293 RVA: 0x00608AC4 File Offset: 0x00606EC4
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
