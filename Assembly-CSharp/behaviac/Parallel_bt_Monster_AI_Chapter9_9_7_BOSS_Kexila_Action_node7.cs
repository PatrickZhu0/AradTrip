using System;

namespace behaviac
{
	// Token: 0x020031FB RID: 12795
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7 : Parallel
	{
		// Token: 0x06014C81 RID: 85121 RVA: 0x00642C4E File Offset: 0x0064104E
		public Parallel_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
