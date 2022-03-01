using System;

namespace behaviac
{
	// Token: 0x02003407 RID: 13319
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Huimie_Action_node42 : Assignment
	{
		// Token: 0x06015060 RID: 86112 RVA: 0x006558C8 File Offset: 0x00653CC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
