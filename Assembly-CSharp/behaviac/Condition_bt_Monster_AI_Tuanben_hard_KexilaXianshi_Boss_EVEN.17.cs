using System;

namespace behaviac
{
	// Token: 0x02003CE3 RID: 15587
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node111 : Condition
	{
		// Token: 0x06016168 RID: 90472 RVA: 0x006ACCC0 File Offset: 0x006AB0C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
