using System;

namespace behaviac
{
	// Token: 0x02003BF7 RID: 15351
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node14 : Condition
	{
		// Token: 0x06015F9C RID: 90012 RVA: 0x006A33F8 File Offset: 0x006A17F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 2;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
