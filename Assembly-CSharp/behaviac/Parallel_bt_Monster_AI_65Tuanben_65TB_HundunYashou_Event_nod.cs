using System;

namespace behaviac
{
	// Token: 0x02002B98 RID: 11160
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node1 : Parallel
	{
		// Token: 0x0601403B RID: 81979 RVA: 0x00602D10 File Offset: 0x00601110
		public Parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node1()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
