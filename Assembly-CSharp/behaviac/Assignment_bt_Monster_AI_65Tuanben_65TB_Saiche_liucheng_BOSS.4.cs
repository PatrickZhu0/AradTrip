using System;

namespace behaviac
{
	// Token: 0x02002BEF RID: 11247
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node59 : Assignment
	{
		// Token: 0x060140DE RID: 82142 RVA: 0x006056AC File Offset: 0x00603AAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
