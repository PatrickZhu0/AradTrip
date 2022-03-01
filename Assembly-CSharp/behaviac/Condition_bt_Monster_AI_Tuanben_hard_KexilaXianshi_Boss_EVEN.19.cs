using System;

namespace behaviac
{
	// Token: 0x02003CE7 RID: 15591
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node112 : Condition
	{
		// Token: 0x06016170 RID: 90480 RVA: 0x006ACDB0 File Offset: 0x006AB1B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
