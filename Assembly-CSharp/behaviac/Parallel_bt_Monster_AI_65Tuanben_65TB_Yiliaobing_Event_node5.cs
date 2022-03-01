using System;

namespace behaviac
{
	// Token: 0x02002D1D RID: 11549
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5 : Parallel
	{
		// Token: 0x06014326 RID: 82726 RVA: 0x00611515 File Offset: 0x0060F915
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node5()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
