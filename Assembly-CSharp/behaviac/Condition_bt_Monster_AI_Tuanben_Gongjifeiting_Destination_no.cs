using System;

namespace behaviac
{
	// Token: 0x020039CA RID: 14794
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node0 : Condition
	{
		// Token: 0x06015B66 RID: 88934 RVA: 0x0068EE48 File Offset: 0x0068D248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 7;
			bool flag = bianshen <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
