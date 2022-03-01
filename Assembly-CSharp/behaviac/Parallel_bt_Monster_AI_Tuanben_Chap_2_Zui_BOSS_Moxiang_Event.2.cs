using System;

namespace behaviac
{
	// Token: 0x020037A1 RID: 14241
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node5 : Parallel
	{
		// Token: 0x06015746 RID: 87878 RVA: 0x00679C31 File Offset: 0x00678031
		public Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
