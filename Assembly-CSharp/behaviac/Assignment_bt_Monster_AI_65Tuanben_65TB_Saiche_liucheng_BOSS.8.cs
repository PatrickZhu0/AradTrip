using System;

namespace behaviac
{
	// Token: 0x02002C06 RID: 11270
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node100 : Assignment
	{
		// Token: 0x0601410C RID: 82188 RVA: 0x00605D1C File Offset: 0x0060411C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 8;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
