using System;

namespace behaviac
{
	// Token: 0x02002E39 RID: 11833
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node120 : Assignment
	{
		// Token: 0x06014550 RID: 83280 RVA: 0x0061AACC File Offset: 0x00618ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
