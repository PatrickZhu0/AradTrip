using System;

namespace behaviac
{
	// Token: 0x0200348F RID: 13455
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Heisedadi_Juewang_Event_node24 : Assignment
	{
		// Token: 0x06015168 RID: 86376 RVA: 0x0065A660 File Offset: 0x00658A60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
