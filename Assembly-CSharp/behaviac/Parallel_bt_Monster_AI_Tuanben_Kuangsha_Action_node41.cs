using System;

namespace behaviac
{
	// Token: 0x02003AB8 RID: 15032
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Kuangsha_Action_node41 : Parallel
	{
		// Token: 0x06015D30 RID: 89392 RVA: 0x0069838E File Offset: 0x0069678E
		public Parallel_bt_Monster_AI_Tuanben_Kuangsha_Action_node41()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
