using System;

namespace behaviac
{
	// Token: 0x02003A93 RID: 14995
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node97 : Parallel
	{
		// Token: 0x06015CEB RID: 89323 RVA: 0x00696C2D File Offset: 0x0069502D
		public Parallel_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node97()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
