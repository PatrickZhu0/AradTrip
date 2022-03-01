using System;

namespace behaviac
{
	// Token: 0x020039F5 RID: 14837
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node0 : Parallel
	{
		// Token: 0x06015BB9 RID: 89017 RVA: 0x00690A64 File Offset: 0x0068EE64
		public Parallel_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
