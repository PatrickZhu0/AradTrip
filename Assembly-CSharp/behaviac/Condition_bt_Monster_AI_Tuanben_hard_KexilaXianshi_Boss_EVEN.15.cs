using System;

namespace behaviac
{
	// Token: 0x02003CDF RID: 15583
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node88 : Condition
	{
		// Token: 0x06016160 RID: 90464 RVA: 0x006ACBD0 File Offset: 0x006AAFD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
