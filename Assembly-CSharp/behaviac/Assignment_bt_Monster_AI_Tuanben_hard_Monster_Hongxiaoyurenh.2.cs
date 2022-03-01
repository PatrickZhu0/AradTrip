using System;

namespace behaviac
{
	// Token: 0x02003D15 RID: 15637
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node8 : Assignment
	{
		// Token: 0x060161C7 RID: 90567 RVA: 0x006AF394 File Offset: 0x006AD794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int monsterID = 81300011;
			((BTAgent)pAgent).monsterID = monsterID;
			return result;
		}
	}
}
