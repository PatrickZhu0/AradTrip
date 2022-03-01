using System;

namespace behaviac
{
	// Token: 0x02003820 RID: 14368
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node0 : Parallel
	{
		// Token: 0x0601582E RID: 88110 RVA: 0x0067E131 File Offset: 0x0067C531
		public Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node0()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
