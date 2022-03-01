using System;

namespace behaviac
{
	// Token: 0x02003AA2 RID: 15010
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node117 : Assignment
	{
		// Token: 0x06015D09 RID: 89353 RVA: 0x00696FA4 File Offset: 0x006953A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
