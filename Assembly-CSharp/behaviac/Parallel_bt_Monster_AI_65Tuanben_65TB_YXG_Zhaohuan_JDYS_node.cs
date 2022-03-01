using System;

namespace behaviac
{
	// Token: 0x02002D37 RID: 11575
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node31 : Parallel
	{
		// Token: 0x06014354 RID: 82772 RVA: 0x00612328 File Offset: 0x00610728
		public Parallel_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node31()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
