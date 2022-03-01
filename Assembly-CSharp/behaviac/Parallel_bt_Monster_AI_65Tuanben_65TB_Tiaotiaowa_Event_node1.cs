using System;

namespace behaviac
{
	// Token: 0x02002D08 RID: 11528
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node1 : Parallel
	{
		// Token: 0x060142FF RID: 82687 RVA: 0x006108AC File Offset: 0x0060ECAC
		public Parallel_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node1()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ALL;
			this.m_exitPolicy = EXIT_POLICY.EXIT_ABORT_RUNNINGSIBLINGS;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
