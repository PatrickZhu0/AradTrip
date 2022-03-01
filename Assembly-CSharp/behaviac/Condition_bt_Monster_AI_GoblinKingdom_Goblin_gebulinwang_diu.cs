using System;

namespace behaviac
{
	// Token: 0x02003323 RID: 13091
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3 : Condition
	{
		// Token: 0x06014EAD RID: 85677 RVA: 0x0064D7A8 File Offset: 0x0064BBA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
