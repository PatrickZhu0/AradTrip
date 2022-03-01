using System;

namespace behaviac
{
	// Token: 0x02003AA5 RID: 15013
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4 : Parallel
	{
		// Token: 0x06015D0D RID: 89357 RVA: 0x006978CB File Offset: 0x00695CCB
		public Parallel_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node4()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
