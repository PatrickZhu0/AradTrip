using System;

namespace behaviac
{
	// Token: 0x020038D1 RID: 14545
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node7 : Parallel
	{
		// Token: 0x06015980 RID: 88448 RVA: 0x00685015 File Offset: 0x00683415
		public Parallel_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
