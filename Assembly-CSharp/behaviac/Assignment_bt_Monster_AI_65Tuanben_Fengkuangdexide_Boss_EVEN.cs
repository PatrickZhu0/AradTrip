using System;

namespace behaviac
{
	// Token: 0x02002EFA RID: 12026
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node15 : Assignment
	{
		// Token: 0x060146CD RID: 83661 RVA: 0x00624CB8 File Offset: 0x006230B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
