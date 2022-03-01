using System;

namespace behaviac
{
	// Token: 0x02003492 RID: 13458
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Juewang_Event_node28 : Assignment
	{
		// Token: 0x0601516E RID: 86382 RVA: 0x0065A730 File Offset: 0x00658B30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
