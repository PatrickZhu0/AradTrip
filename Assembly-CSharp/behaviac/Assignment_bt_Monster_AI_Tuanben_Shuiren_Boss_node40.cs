using System;

namespace behaviac
{
	// Token: 0x02003B23 RID: 15139
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node40 : Assignment
	{
		// Token: 0x06015DFF RID: 89599 RVA: 0x0069C014 File Offset: 0x0069A414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
