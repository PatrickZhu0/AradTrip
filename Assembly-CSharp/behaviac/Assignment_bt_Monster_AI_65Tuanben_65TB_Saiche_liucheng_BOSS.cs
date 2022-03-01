using System;

namespace behaviac
{
	// Token: 0x02002BDD RID: 11229
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node23 : Assignment
	{
		// Token: 0x060140BA RID: 82106 RVA: 0x0060518C File Offset: 0x0060358C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
