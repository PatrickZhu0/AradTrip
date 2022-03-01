using System;

namespace behaviac
{
	// Token: 0x02003CE8 RID: 15592
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node116 : Assignment
	{
		// Token: 0x06016172 RID: 90482 RVA: 0x006ACDE8 File Offset: 0x006AB1E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
