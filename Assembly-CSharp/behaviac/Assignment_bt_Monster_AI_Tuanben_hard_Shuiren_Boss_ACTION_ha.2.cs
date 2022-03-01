using System;

namespace behaviac
{
	// Token: 0x02003D40 RID: 15680
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node65 : Assignment
	{
		// Token: 0x06016217 RID: 90647 RVA: 0x006B091C File Offset: 0x006AED1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
