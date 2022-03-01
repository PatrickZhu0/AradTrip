using System;

namespace behaviac
{
	// Token: 0x020037D0 RID: 14288
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node4 : Parallel
	{
		// Token: 0x0601579D RID: 87965 RVA: 0x0067B6E2 File Offset: 0x00679AE2
		public Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Qiweiqiutai_Hard_node4()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ONE;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
