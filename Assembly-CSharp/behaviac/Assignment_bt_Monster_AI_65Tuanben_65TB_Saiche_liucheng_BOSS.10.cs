using System;

namespace behaviac
{
	// Token: 0x02002C1A RID: 11290
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node130 : Assignment
	{
		// Token: 0x06014134 RID: 82228 RVA: 0x006062C8 File Offset: 0x006046C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 10;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
