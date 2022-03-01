using System;

namespace behaviac
{
	// Token: 0x02003D87 RID: 15751
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node43 : Assignment
	{
		// Token: 0x060162A4 RID: 90788 RVA: 0x006B315C File Offset: 0x006B155C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 6;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
