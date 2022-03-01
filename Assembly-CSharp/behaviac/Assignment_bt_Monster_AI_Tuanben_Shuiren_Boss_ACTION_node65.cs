using System;

namespace behaviac
{
	// Token: 0x02003B46 RID: 15174
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node65 : Assignment
	{
		// Token: 0x06015E42 RID: 89666 RVA: 0x0069D52C File Offset: 0x0069B92C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
