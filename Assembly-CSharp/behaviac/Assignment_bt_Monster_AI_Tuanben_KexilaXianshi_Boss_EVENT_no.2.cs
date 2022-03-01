using System;

namespace behaviac
{
	// Token: 0x02003A96 RID: 14998
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node95 : Assignment
	{
		// Token: 0x06015CF1 RID: 89329 RVA: 0x00696CD4 File Offset: 0x006950D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
