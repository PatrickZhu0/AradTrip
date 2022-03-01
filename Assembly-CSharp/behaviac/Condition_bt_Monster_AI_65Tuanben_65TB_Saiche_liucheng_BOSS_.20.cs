using System;

namespace behaviac
{
	// Token: 0x02002C07 RID: 11271
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node106 : Condition
	{
		// Token: 0x0601410E RID: 82190 RVA: 0x00605D44 File Offset: 0x00604144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 8;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
