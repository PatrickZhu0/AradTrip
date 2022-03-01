using System;

namespace behaviac
{
	// Token: 0x02002C65 RID: 11365
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node5 : Parallel
	{
		// Token: 0x060141C4 RID: 82372 RVA: 0x0060A420 File Offset: 0x00608820
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
