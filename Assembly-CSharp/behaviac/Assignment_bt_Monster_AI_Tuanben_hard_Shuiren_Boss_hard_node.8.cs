using System;

namespace behaviac
{
	// Token: 0x02003D8F RID: 15759
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node44 : Assignment
	{
		// Token: 0x060162B4 RID: 90804 RVA: 0x006B342C File Offset: 0x006B182C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 8;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
