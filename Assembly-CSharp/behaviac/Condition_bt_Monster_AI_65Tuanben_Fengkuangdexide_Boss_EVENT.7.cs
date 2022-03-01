using System;

namespace behaviac
{
	// Token: 0x02002EFE RID: 12030
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node13 : Condition
	{
		// Token: 0x060146D5 RID: 83669 RVA: 0x00624E08 File Offset: 0x00623208
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
