using System;

namespace behaviac
{
	// Token: 0x02003153 RID: 12627
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node5 : Parallel
	{
		// Token: 0x06014B46 RID: 84806 RVA: 0x0063C4D8 File Offset: 0x0063A8D8
		public Parallel_bt_Monster_AI_Chapter10_Yiliaobing_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
