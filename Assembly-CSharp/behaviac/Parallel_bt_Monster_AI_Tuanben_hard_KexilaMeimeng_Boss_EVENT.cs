using System;

namespace behaviac
{
	// Token: 0x02003C50 RID: 15440
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node33 : Parallel
	{
		// Token: 0x06016049 RID: 90185 RVA: 0x006A7B39 File Offset: 0x006A5F39
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node33()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
