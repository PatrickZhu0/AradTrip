using System;

namespace behaviac
{
	// Token: 0x02003899 RID: 14489
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node11 : Parallel
	{
		// Token: 0x06015915 RID: 88341 RVA: 0x00682F54 File Offset: 0x00681354
		public Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node11()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
