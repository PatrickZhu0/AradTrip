using System;

namespace behaviac
{
	// Token: 0x02003362 RID: 13154
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node11 : Condition
	{
		// Token: 0x06014F24 RID: 85796 RVA: 0x0064F91C File Offset: 0x0064DD1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsSelfInCircle();
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
