using System;

namespace behaviac
{
	// Token: 0x02003376 RID: 13174
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node3 : Condition
	{
		// Token: 0x06014F4A RID: 85834 RVA: 0x0065064C File Offset: 0x0064EA4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
