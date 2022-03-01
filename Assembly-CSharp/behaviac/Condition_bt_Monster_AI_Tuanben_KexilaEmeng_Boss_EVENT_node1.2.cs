using System;

namespace behaviac
{
	// Token: 0x020039FA RID: 14842
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node1 : Condition
	{
		// Token: 0x06015BC3 RID: 89027 RVA: 0x00690BC4 File Offset: 0x0068EFC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
