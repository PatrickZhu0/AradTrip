using System;

namespace behaviac
{
	// Token: 0x02002DB6 RID: 11702
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node11 : Parallel
	{
		// Token: 0x0601444C RID: 83020 RVA: 0x006174E6 File Offset: 0x006158E6
		public Parallel_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node11()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
