using System;

namespace behaviac
{
	// Token: 0x02002BF5 RID: 11253
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node70 : Assignment
	{
		// Token: 0x060140EA RID: 82154 RVA: 0x00605860 File Offset: 0x00603C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 5;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
