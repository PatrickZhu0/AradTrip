using System;

namespace behaviac
{
	// Token: 0x02003AE3 RID: 15075
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_action_node7 : Assignment
	{
		// Token: 0x06015D85 RID: 89477 RVA: 0x00699E38 File Offset: 0x00698238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
