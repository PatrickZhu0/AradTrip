using System;

namespace behaviac
{
	// Token: 0x02003543 RID: 13635
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node1 : Parallel
	{
		// Token: 0x060152C8 RID: 86728 RVA: 0x00661C32 File Offset: 0x00660032
		public Parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node1()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
