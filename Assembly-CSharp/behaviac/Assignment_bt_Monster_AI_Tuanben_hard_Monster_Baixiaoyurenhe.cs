using System;

namespace behaviac
{
	// Token: 0x02003D02 RID: 15618
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node7 : Assignment
	{
		// Token: 0x060161A3 RID: 90531 RVA: 0x006AE958 File Offset: 0x006ACD58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
