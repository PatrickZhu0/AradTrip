using System;

namespace behaviac
{
	// Token: 0x02002BFB RID: 11259
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node74 : Assignment
	{
		// Token: 0x060140F6 RID: 82166 RVA: 0x006059C0 File Offset: 0x00603DC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 6;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
