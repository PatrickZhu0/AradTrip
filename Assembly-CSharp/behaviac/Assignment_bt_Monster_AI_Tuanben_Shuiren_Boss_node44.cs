using System;

namespace behaviac
{
	// Token: 0x02003B37 RID: 15159
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node44 : Assignment
	{
		// Token: 0x06015E27 RID: 89639 RVA: 0x0069C71C File Offset: 0x0069AB1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 8;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
