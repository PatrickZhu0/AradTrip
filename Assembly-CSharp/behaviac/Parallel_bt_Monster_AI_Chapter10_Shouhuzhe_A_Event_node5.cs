using System;

namespace behaviac
{
	// Token: 0x0200311F RID: 12575
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node5 : Parallel
	{
		// Token: 0x06014AE4 RID: 84708 RVA: 0x0063A5EA File Offset: 0x006389EA
		public Parallel_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
