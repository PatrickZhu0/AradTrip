using System;

namespace behaviac
{
	// Token: 0x02003D7F RID: 15743
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node41 : Assignment
	{
		// Token: 0x06016294 RID: 90772 RVA: 0x006B2E8C File Offset: 0x006B128C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
