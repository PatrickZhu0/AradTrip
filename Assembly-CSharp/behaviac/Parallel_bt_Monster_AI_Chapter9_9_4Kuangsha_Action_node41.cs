using System;

namespace behaviac
{
	// Token: 0x0200316B RID: 12651
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node41 : Parallel
	{
		// Token: 0x06014B6E RID: 84846 RVA: 0x0063D144 File Offset: 0x0063B544
		public Parallel_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node41()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
