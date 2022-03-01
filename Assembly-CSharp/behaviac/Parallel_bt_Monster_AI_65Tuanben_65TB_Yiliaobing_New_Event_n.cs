using System;

namespace behaviac
{
	// Token: 0x02002D27 RID: 11559
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node5 : Parallel
	{
		// Token: 0x06014338 RID: 82744 RVA: 0x00611AA3 File Offset: 0x0060FEA3
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
