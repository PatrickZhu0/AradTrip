using System;

namespace behaviac
{
	// Token: 0x02002BE9 RID: 11241
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node60 : Assignment
	{
		// Token: 0x060140D2 RID: 82130 RVA: 0x006054A0 File Offset: 0x006038A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
