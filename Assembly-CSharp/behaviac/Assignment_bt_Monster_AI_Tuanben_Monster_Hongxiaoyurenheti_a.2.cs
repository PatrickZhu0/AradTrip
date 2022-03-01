using System;

namespace behaviac
{
	// Token: 0x02003AF6 RID: 15094
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node8 : Assignment
	{
		// Token: 0x06015DA9 RID: 89513 RVA: 0x0069A874 File Offset: 0x00698C74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int monsterID = 80030011;
			((BTAgent)pAgent).monsterID = monsterID;
			return result;
		}
	}
}
