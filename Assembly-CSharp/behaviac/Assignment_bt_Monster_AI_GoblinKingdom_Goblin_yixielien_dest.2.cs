using System;

namespace behaviac
{
	// Token: 0x0200335D RID: 13149
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node4 : Assignment
	{
		// Token: 0x06014F1A RID: 85786 RVA: 0x0064F7FC File Offset: 0x0064DBFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int monsterID = 30230011;
			((BTAgent)pAgent).monsterID = monsterID;
			return result;
		}
	}
}
