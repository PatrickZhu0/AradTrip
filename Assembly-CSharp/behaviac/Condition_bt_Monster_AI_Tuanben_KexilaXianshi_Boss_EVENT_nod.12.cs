using System;

namespace behaviac
{
	// Token: 0x02003AA1 RID: 15009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node115 : Condition
	{
		// Token: 0x06015D07 RID: 89351 RVA: 0x00696F6C File Offset: 0x0069536C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 3;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
