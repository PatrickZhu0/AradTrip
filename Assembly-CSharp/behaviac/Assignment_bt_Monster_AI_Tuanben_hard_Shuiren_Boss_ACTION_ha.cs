using System;

namespace behaviac
{
	// Token: 0x02003D3C RID: 15676
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node63 : Assignment
	{
		// Token: 0x0601620F RID: 90639 RVA: 0x006B0830 File Offset: 0x006AEC30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
