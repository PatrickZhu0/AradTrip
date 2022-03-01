using System;

namespace behaviac
{
	// Token: 0x02003D77 RID: 15735
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node39 : Assignment
	{
		// Token: 0x06016284 RID: 90756 RVA: 0x006B2BBC File Offset: 0x006B0FBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
