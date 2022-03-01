using System;

namespace behaviac
{
	// Token: 0x02003CE0 RID: 15584
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node95 : Assignment
	{
		// Token: 0x06016162 RID: 90466 RVA: 0x006ACC08 File Offset: 0x006AB008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
