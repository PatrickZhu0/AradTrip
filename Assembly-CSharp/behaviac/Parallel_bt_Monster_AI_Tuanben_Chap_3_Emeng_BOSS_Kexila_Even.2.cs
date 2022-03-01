using System;

namespace behaviac
{
	// Token: 0x020038A9 RID: 14505
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node11 : Parallel
	{
		// Token: 0x06015933 RID: 88371 RVA: 0x006838D9 File Offset: 0x00681CD9
		public Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node11()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
