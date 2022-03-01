using System;

namespace behaviac
{
	// Token: 0x02002BE3 RID: 11235
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node12 : Assignment
	{
		// Token: 0x060140C6 RID: 82118 RVA: 0x00605340 File Offset: 0x00603740
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
