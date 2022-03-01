using System;

namespace behaviac
{
	// Token: 0x02003B3B RID: 15163
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node29 : Assignment
	{
		// Token: 0x06015E2F RID: 89647 RVA: 0x0069C884 File Offset: 0x0069AC84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 9;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
