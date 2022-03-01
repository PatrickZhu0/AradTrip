using System;

namespace behaviac
{
	// Token: 0x02002EF8 RID: 12024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node12 : Condition
	{
		// Token: 0x060146C9 RID: 83657 RVA: 0x00624C20 File Offset: 0x00623020
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
