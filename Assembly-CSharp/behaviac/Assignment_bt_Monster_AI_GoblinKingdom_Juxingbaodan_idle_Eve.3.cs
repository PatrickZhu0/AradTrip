using System;

namespace behaviac
{
	// Token: 0x02003390 RID: 13200
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node18 : Assignment
	{
		// Token: 0x06014F7E RID: 85886 RVA: 0x00650F58 File Offset: 0x0064F358
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
