using System;

namespace behaviac
{
	// Token: 0x02003956 RID: 14678
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node5 : Parallel
	{
		// Token: 0x06015A85 RID: 88709 RVA: 0x0068ADAD File Offset: 0x006891AD
		public Parallel_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
