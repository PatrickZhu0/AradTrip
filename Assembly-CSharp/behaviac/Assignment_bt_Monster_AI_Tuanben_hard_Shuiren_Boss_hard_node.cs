using System;

namespace behaviac
{
	// Token: 0x02003D73 RID: 15731
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node31 : Assignment
	{
		// Token: 0x0601627C RID: 90748 RVA: 0x006B2A54 File Offset: 0x006B0E54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
