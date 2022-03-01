using System;

namespace behaviac
{
	// Token: 0x02003CEF RID: 15599
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node4 : Parallel
	{
		// Token: 0x0601617E RID: 90494 RVA: 0x006ADE5C File Offset: 0x006AC25C
		public Parallel_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node4()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
