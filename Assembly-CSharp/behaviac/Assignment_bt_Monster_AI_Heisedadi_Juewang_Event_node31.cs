using System;

namespace behaviac
{
	// Token: 0x02003495 RID: 13461
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Juewang_Event_node31 : Assignment
	{
		// Token: 0x06015174 RID: 86388 RVA: 0x0065A800 File Offset: 0x00658C00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
