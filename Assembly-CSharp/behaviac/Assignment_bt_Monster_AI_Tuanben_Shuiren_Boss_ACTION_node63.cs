using System;

namespace behaviac
{
	// Token: 0x02003B42 RID: 15170
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node63 : Assignment
	{
		// Token: 0x06015E3A RID: 89658 RVA: 0x0069D440 File Offset: 0x0069B840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
