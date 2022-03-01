using System;

namespace behaviac
{
	// Token: 0x02002B0D RID: 11021
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Level_Tuanben_TuanBen_Wind_hard_node36 : Parallel
	{
		// Token: 0x06013F2D RID: 81709 RVA: 0x005FD365 File Offset: 0x005FB765
		public Parallel_bt_Level_Tuanben_TuanBen_Wind_hard_node36()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
