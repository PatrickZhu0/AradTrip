using System;

namespace behaviac
{
	// Token: 0x02003D26 RID: 15654
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node7 : Assignment
	{
		// Token: 0x060161E7 RID: 90599 RVA: 0x006AFD70 File Offset: 0x006AE170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
