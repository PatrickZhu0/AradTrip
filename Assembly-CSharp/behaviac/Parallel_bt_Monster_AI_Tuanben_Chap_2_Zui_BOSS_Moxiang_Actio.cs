using System;

namespace behaviac
{
	// Token: 0x02003749 RID: 14153
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node7 : Parallel
	{
		// Token: 0x0601569A RID: 87706 RVA: 0x00675F92 File Offset: 0x00674392
		public Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
