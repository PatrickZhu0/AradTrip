using System;

namespace behaviac
{
	// Token: 0x02002BDE RID: 11230
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node11 : Condition
	{
		// Token: 0x060140BC RID: 82108 RVA: 0x006051B4 File Offset: 0x006035B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
