using System;

namespace behaviac
{
	// Token: 0x02002BF0 RID: 11248
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node66 : Condition
	{
		// Token: 0x060140E0 RID: 82144 RVA: 0x006056D4 File Offset: 0x00603AD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 4;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
