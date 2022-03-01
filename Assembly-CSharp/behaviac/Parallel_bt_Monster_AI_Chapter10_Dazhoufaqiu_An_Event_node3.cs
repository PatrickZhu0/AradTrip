using System;

namespace behaviac
{
	// Token: 0x020030EC RID: 12524
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node3 : Parallel
	{
		// Token: 0x06014A8A RID: 84618 RVA: 0x00638A36 File Offset: 0x00636E36
		public Parallel_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node3()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
