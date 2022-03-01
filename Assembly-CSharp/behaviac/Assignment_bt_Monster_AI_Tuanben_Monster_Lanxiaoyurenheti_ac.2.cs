using System;

namespace behaviac
{
	// Token: 0x02003B08 RID: 15112
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node8 : Assignment
	{
		// Token: 0x06015DCB RID: 89547 RVA: 0x0069B280 File Offset: 0x00699680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int monsterID = 80010011;
			((BTAgent)pAgent).monsterID = monsterID;
			return result;
		}
	}
}
