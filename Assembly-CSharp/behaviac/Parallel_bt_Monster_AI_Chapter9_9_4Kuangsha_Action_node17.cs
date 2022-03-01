using System;

namespace behaviac
{
	// Token: 0x0200316A RID: 12650
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node17 : Parallel
	{
		// Token: 0x06014B6D RID: 84845 RVA: 0x0063D120 File Offset: 0x0063B520
		public Parallel_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node17()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
