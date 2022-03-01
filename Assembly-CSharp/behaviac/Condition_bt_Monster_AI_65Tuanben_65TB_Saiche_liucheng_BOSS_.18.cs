using System;

namespace behaviac
{
	// Token: 0x02002C02 RID: 11266
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node99 : Condition
	{
		// Token: 0x06014104 RID: 82180 RVA: 0x00605BF4 File Offset: 0x00603FF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 7;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
