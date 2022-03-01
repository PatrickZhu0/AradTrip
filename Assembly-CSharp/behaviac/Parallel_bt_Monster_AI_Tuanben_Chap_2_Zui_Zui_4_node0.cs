using System;

namespace behaviac
{
	// Token: 0x0200380A RID: 14346
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node0 : Parallel
	{
		// Token: 0x06015804 RID: 88068 RVA: 0x0067D4C8 File Offset: 0x0067B8C8
		public Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
