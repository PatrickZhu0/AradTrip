using System;

namespace behaviac
{
	// Token: 0x02002AEF RID: 10991
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Level_Tuanben_TuanBen_Wind_node36 : Parallel
	{
		// Token: 0x06013EF3 RID: 81651 RVA: 0x005FC0BE File Offset: 0x005FA4BE
		public Parallel_bt_Level_Tuanben_TuanBen_Wind_node36()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
