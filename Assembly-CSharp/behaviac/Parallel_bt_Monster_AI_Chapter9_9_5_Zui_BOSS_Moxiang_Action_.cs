using System;

namespace behaviac
{
	// Token: 0x02003199 RID: 12697
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node7 : Parallel
	{
		// Token: 0x06014BC6 RID: 84934 RVA: 0x0063ED4E File Offset: 0x0063D14E
		public Parallel_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node7()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
