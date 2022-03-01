using System;

namespace behaviac
{
	// Token: 0x02002BEA RID: 11242
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node58 : Condition
	{
		// Token: 0x060140D4 RID: 82132 RVA: 0x006054C8 File Offset: 0x006038C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
