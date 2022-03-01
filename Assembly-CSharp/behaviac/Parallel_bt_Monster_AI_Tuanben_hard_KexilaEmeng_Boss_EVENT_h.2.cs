using System;

namespace behaviac
{
	// Token: 0x02003BC4 RID: 15300
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node33 : Parallel
	{
		// Token: 0x06015F36 RID: 89910 RVA: 0x006A25B1 File Offset: 0x006A09B1
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node33()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
