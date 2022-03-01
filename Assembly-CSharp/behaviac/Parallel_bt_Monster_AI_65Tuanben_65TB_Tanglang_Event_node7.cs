using System;

namespace behaviac
{
	// Token: 0x02002CA1 RID: 11425
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node7 : Parallel
	{
		// Token: 0x06014238 RID: 82488 RVA: 0x0060C9DF File Offset: 0x0060ADDF
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
