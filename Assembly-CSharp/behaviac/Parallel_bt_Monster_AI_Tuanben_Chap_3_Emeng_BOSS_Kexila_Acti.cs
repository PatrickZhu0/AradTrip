using System;

namespace behaviac
{
	// Token: 0x02003839 RID: 14393
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node7 : Parallel
	{
		// Token: 0x06015859 RID: 88153 RVA: 0x0067ED5A File Offset: 0x0067D15A
		public Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
