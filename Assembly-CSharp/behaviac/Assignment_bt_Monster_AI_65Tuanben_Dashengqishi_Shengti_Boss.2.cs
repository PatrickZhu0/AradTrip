using System;

namespace behaviac
{
	// Token: 0x02002DD7 RID: 11735
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node76 : Assignment
	{
		// Token: 0x0601448C RID: 83084 RVA: 0x00618448 File Offset: 0x00616848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
