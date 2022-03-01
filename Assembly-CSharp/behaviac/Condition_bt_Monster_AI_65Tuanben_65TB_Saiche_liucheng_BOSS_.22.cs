using System;

namespace behaviac
{
	// Token: 0x02002C0D RID: 11277
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node9 : Condition
	{
		// Token: 0x0601411A RID: 82202 RVA: 0x00605EA4 File Offset: 0x006042A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 9;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
