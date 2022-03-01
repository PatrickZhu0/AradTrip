using System;

namespace behaviac
{
	// Token: 0x0200342B RID: 13355
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Heisedadi_Huimie_Event_node52 : Parallel
	{
		// Token: 0x060150A5 RID: 86181 RVA: 0x00656BAE File Offset: 0x00654FAE
		public Parallel_bt_Monster_AI_Heisedadi_Huimie_Event_node52()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ONE;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
