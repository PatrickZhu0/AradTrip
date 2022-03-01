using System;

namespace behaviac
{
	// Token: 0x02003134 RID: 12596
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node5 : Parallel
	{
		// Token: 0x06014B0C RID: 84748 RVA: 0x0063B2CF File Offset: 0x006396CF
		public Parallel_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
