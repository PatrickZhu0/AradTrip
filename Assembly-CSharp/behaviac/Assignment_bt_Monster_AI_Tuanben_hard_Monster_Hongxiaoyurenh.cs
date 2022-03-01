using System;

namespace behaviac
{
	// Token: 0x02003D14 RID: 15636
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Monster_Hongxiaoyurenheti_action_hard_node7 : Assignment
	{
		// Token: 0x060161C5 RID: 90565 RVA: 0x006AF364 File Offset: 0x006AD764
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
