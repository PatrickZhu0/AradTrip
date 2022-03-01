using System;

namespace behaviac
{
	// Token: 0x02003B33 RID: 15155
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node45 : Assignment
	{
		// Token: 0x06015E1F RID: 89631 RVA: 0x0069C5B4 File Offset: 0x0069A9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 7;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
