using System;

namespace behaviac
{
	// Token: 0x02003326 RID: 13094
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node5 : Assignment
	{
		// Token: 0x06014EB3 RID: 85683 RVA: 0x0064D888 File Offset: 0x0064BC88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
