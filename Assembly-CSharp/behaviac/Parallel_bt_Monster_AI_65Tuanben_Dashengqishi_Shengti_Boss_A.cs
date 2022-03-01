using System;

namespace behaviac
{
	// Token: 0x02002DCB RID: 11723
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node0 : Parallel
	{
		// Token: 0x06014474 RID: 83060 RVA: 0x0061805B File Offset: 0x0061645B
		public Parallel_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
