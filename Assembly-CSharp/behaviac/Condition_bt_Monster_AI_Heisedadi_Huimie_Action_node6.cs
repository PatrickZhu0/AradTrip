using System;

namespace behaviac
{
	// Token: 0x02003408 RID: 13320
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node6 : Condition
	{
		// Token: 0x06015062 RID: 86114 RVA: 0x006558F0 File Offset: 0x00653CF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
