using System;

namespace behaviac
{
	// Token: 0x02002CCC RID: 11468
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node3 : Parallel
	{
		// Token: 0x0601428B RID: 82571 RVA: 0x0060E2E4 File Offset: 0x0060C6E4
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Event_node3()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
