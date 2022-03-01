using System;

namespace behaviac
{
	// Token: 0x02002C0C RID: 11276
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node107 : Assignment
	{
		// Token: 0x06014118 RID: 82200 RVA: 0x00605E7C File Offset: 0x0060427C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 6;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
