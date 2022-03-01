using System;

namespace behaviac
{
	// Token: 0x0200338A RID: 13194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node14 : Condition
	{
		// Token: 0x06014F72 RID: 85874 RVA: 0x00650D24 File Offset: 0x0064F124
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
