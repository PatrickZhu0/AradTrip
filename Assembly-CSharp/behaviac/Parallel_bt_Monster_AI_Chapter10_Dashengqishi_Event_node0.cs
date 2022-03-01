using System;

namespace behaviac
{
	// Token: 0x020030E2 RID: 12514
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node0 : Parallel
	{
		// Token: 0x06014A78 RID: 84600 RVA: 0x0063842E File Offset: 0x0063682E
		public Parallel_bt_Monster_AI_Chapter10_Dashengqishi_Event_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
