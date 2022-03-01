using System;

namespace behaviac
{
	// Token: 0x02003D8B RID: 15755
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node45 : Assignment
	{
		// Token: 0x060162AC RID: 90796 RVA: 0x006B32C4 File Offset: 0x006B16C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 7;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
