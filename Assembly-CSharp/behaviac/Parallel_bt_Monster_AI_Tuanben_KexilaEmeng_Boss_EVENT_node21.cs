using System;

namespace behaviac
{
	// Token: 0x02003A09 RID: 14857
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node21 : Parallel
	{
		// Token: 0x06015BE0 RID: 89056 RVA: 0x00690EE4 File Offset: 0x0068F2E4
		public Parallel_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node21()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
