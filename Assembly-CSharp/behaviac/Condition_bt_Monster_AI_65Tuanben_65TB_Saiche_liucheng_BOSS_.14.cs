using System;

namespace behaviac
{
	// Token: 0x02002BF6 RID: 11254
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node73 : Condition
	{
		// Token: 0x060140EC RID: 82156 RVA: 0x00605888 File Offset: 0x00603C88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 5;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
