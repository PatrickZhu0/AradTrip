using System;

namespace behaviac
{
	// Token: 0x02003488 RID: 13448
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node25 : Condition
	{
		// Token: 0x0601515A RID: 86362 RVA: 0x0065A450 File Offset: 0x00658850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
