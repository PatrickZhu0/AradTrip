using System;

namespace behaviac
{
	// Token: 0x02002E86 RID: 11910
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node10 : Assignment
	{
		// Token: 0x060145E8 RID: 83432 RVA: 0x00620820 File Offset: 0x0061EC20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
