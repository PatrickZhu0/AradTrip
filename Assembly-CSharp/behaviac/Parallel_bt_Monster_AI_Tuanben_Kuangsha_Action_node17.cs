using System;

namespace behaviac
{
	// Token: 0x02003AB7 RID: 15031
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Kuangsha_Action_node17 : Parallel
	{
		// Token: 0x06015D2F RID: 89391 RVA: 0x0069836A File Offset: 0x0069676A
		public Parallel_bt_Monster_AI_Tuanben_Kuangsha_Action_node17()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
