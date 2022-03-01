using System;

namespace behaviac
{
	// Token: 0x02003B3D RID: 15165
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node14 : Parallel
	{
		// Token: 0x06015E31 RID: 89649 RVA: 0x0069D329 File Offset: 0x0069B729
		public Parallel_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node14()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
