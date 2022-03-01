using System;

namespace behaviac
{
	// Token: 0x02003352 RID: 13138
	[GeneratedTypeMetaInfo]
	internal class Parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2 : Parallel
	{
		// Token: 0x06014F05 RID: 85765 RVA: 0x0064F2CD File Offset: 0x0064D6CD
		public Parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2()
		{
			this.m_failPolicy = FAILURE_POLICY.FAIL_ON_ALL;
			this.m_succeedPolicy = SUCCESS_POLICY.SUCCEED_ON_ONE;
			this.m_exitPolicy = EXIT_POLICY.EXIT_NONE;
			this.m_childFinishPolicy = CHILDFINISH_POLICY.CHILDFINISH_LOOP;
		}
	}
}
