using System;

namespace behaviac
{
	// Token: 0x02003D93 RID: 15763
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node29 : Assignment
	{
		// Token: 0x060162BC RID: 90812 RVA: 0x006B3594 File Offset: 0x006B1994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 9;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
