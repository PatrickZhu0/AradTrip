using System;

namespace behaviac
{
	// Token: 0x02003CEB RID: 15595
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node115 : Condition
	{
		// Token: 0x06016178 RID: 90488 RVA: 0x006ACEA0 File Offset: 0x006AB2A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
