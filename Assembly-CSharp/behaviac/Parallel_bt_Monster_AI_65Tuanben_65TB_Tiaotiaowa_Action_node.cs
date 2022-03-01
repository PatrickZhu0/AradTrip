using System;

namespace behaviac
{
	// Token: 0x02002CD2 RID: 11474
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node35 : Parallel
	{
		// Token: 0x06014295 RID: 82581 RVA: 0x0060E609 File Offset: 0x0060CA09
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node35()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
