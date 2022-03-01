using System;

namespace behaviac
{
	// Token: 0x02003BFB RID: 15355
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node21 : Parallel
	{
		// Token: 0x06015FA3 RID: 90019 RVA: 0x006A34AC File Offset: 0x006A18AC
		public Parallel_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node21()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
