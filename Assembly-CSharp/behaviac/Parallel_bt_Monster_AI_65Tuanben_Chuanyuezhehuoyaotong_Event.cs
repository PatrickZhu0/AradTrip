using System;

namespace behaviac
{
	// Token: 0x02002D53 RID: 11603
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node0 : Parallel
	{
		// Token: 0x0601438A RID: 82826 RVA: 0x006131E8 File Offset: 0x006115E8
		public Parallel_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
