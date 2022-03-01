using System;

namespace behaviac
{
	// Token: 0x02002BB9 RID: 11193
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node16 : Parallel
	{
		// Token: 0x06014077 RID: 82039 RVA: 0x00604192 File Offset: 0x00602592
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node16()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
