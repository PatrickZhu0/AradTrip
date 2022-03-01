using System;

namespace behaviac
{
	// Token: 0x020037FF RID: 14335
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node0 : Parallel
	{
		// Token: 0x060157F0 RID: 88048 RVA: 0x0067CE92 File Offset: 0x0067B292
		public Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
