using System;

namespace behaviac
{
	// Token: 0x02003AE4 RID: 15076
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node8 : Assignment
	{
		// Token: 0x06015D87 RID: 89479 RVA: 0x00699E68 File Offset: 0x00698268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int monsterID = 80020011;
			((BTAgent)pAgent).monsterID = monsterID;
			return result;
		}
	}
}
