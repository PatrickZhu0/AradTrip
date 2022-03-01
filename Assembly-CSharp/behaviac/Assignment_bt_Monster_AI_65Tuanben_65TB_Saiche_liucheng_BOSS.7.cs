using System;

namespace behaviac
{
	// Token: 0x02002C01 RID: 11265
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node80 : Assignment
	{
		// Token: 0x06014102 RID: 82178 RVA: 0x00605BCC File Offset: 0x00603FCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 7;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
