using System;

namespace behaviac
{
	// Token: 0x02003B3E RID: 15166
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node34 : Parallel
	{
		// Token: 0x06015E32 RID: 89650 RVA: 0x0069D34D File Offset: 0x0069B74D
		public Parallel_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node34()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
