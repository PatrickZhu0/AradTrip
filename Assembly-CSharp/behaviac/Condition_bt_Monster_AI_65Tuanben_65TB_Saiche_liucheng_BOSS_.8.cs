using System;

namespace behaviac
{
	// Token: 0x02002BE4 RID: 11236
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node57 : Condition
	{
		// Token: 0x060140C8 RID: 82120 RVA: 0x00605368 File Offset: 0x00603768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
