using System;

namespace behaviac
{
	// Token: 0x02003BC3 RID: 15299
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node0 : Parallel
	{
		// Token: 0x06015F35 RID: 89909 RVA: 0x006A258D File Offset: 0x006A098D
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
