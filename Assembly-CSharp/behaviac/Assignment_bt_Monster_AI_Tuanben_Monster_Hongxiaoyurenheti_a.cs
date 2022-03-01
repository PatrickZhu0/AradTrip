using System;

namespace behaviac
{
	// Token: 0x02003AF5 RID: 15093
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node7 : Assignment
	{
		// Token: 0x06015DA7 RID: 89511 RVA: 0x0069A844 File Offset: 0x00698C44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
