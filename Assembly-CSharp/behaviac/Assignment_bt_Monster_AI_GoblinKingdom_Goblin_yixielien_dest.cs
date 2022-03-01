using System;

namespace behaviac
{
	// Token: 0x0200335C RID: 13148
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node7 : Assignment
	{
		// Token: 0x06014F18 RID: 85784 RVA: 0x0064F7CC File Offset: 0x0064DBCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int value = 1000;
			pAgent.SetVariable<int>("radius", 1327198659U, value);
			return result;
		}
	}
}
