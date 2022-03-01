using System;

namespace behaviac
{
	// Token: 0x02003442 RID: 13378
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Heisedadi_Hundun_Event_node3 : Parallel
	{
		// Token: 0x060150D1 RID: 86225 RVA: 0x00657F03 File Offset: 0x00656303
		public Parallel_bt_Monster_AI_Heisedadi_Hundun_Event_node3()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
