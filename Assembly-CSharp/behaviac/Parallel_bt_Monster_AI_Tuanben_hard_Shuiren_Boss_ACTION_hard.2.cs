using System;

namespace behaviac
{
	// Token: 0x02003D38 RID: 15672
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node34 : Parallel
	{
		// Token: 0x06016207 RID: 90631 RVA: 0x006B0740 File Offset: 0x006AEB40
		public Parallel_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node34()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
