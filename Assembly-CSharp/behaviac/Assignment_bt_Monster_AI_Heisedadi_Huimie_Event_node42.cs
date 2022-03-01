using System;

namespace behaviac
{
	// Token: 0x02003428 RID: 13352
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Huimie_Event_node42 : Assignment
	{
		// Token: 0x060150A0 RID: 86176 RVA: 0x00656A9C File Offset: 0x00654E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
