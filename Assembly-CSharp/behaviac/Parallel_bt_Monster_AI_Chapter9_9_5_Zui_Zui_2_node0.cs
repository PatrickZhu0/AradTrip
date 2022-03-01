using System;

namespace behaviac
{
	// Token: 0x020031E6 RID: 12774
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node0 : Parallel
	{
		// Token: 0x06014C59 RID: 85081 RVA: 0x00642055 File Offset: 0x00640455
		public Parallel_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
