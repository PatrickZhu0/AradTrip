using System;

namespace behaviac
{
	// Token: 0x0200398B RID: 14731
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Eyujingyin_Event_node3 : Parallel
	{
		// Token: 0x06015AEC RID: 88812 RVA: 0x0068CB1D File Offset: 0x0068AF1D
		public Parallel_bt_Monster_AI_Tuanben_Eyujingyin_Event_node3()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
