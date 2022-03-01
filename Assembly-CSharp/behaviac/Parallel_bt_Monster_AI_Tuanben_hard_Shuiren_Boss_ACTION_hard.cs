using System;

namespace behaviac
{
	// Token: 0x02003D37 RID: 15671
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node14 : Parallel
	{
		// Token: 0x06016206 RID: 90630 RVA: 0x006B071C File Offset: 0x006AEB1C
		public Parallel_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node14()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
