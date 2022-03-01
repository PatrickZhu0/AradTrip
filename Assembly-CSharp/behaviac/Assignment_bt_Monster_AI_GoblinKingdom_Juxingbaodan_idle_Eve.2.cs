using System;

namespace behaviac
{
	// Token: 0x02003386 RID: 13190
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node13 : Assignment
	{
		// Token: 0x06014F6A RID: 85866 RVA: 0x00650BEC File Offset: 0x0064EFEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
