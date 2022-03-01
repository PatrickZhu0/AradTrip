using System;

namespace behaviac
{
	// Token: 0x02003B2F RID: 15151
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_node43 : Assignment
	{
		// Token: 0x06015E17 RID: 89623 RVA: 0x0069C44C File Offset: 0x0069A84C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 6;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
