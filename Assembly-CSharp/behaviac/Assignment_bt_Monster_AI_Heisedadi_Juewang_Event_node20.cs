using System;

namespace behaviac
{
	// Token: 0x0200348C RID: 13452
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Juewang_Event_node20 : Assignment
	{
		// Token: 0x06015162 RID: 86370 RVA: 0x0065A590 File Offset: 0x00658990
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
