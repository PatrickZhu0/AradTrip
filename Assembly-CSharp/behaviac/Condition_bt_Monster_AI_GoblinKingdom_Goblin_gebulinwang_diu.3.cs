using System;

namespace behaviac
{
	// Token: 0x02003328 RID: 13096
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node8 : Condition
	{
		// Token: 0x06014EB7 RID: 85687 RVA: 0x0064D8F8 File Offset: 0x0064BCF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
