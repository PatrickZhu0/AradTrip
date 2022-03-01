using System;

namespace behaviac
{
	// Token: 0x02003172 RID: 12658
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node8 : Assignment
	{
		// Token: 0x06014B7C RID: 84860 RVA: 0x0063D34C File Offset: 0x0063B74C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
