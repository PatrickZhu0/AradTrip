using System;

namespace behaviac
{
	// Token: 0x0200356E RID: 13678
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node3 : Parallel
	{
		// Token: 0x06015313 RID: 86803 RVA: 0x00663254 File Offset: 0x00661654
		public Parallel_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node3()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
