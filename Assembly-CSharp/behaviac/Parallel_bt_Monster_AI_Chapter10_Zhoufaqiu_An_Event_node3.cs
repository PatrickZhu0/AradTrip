using System;

namespace behaviac
{
	// Token: 0x02003161 RID: 12641
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3 : Parallel
	{
		// Token: 0x06014B5E RID: 84830 RVA: 0x0063CC7A File Offset: 0x0063B07A
		public Parallel_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node3()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
