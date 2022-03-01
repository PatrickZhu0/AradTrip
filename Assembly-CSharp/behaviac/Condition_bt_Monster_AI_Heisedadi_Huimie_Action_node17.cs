using System;

namespace behaviac
{
	// Token: 0x02003405 RID: 13317
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node17 : Condition
	{
		// Token: 0x0601505C RID: 86108 RVA: 0x00655830 File Offset: 0x00653C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
