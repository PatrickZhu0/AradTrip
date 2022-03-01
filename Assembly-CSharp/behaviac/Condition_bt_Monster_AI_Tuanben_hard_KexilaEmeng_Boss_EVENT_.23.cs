using System;

namespace behaviac
{
	// Token: 0x02003BF3 RID: 15347
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node7 : Condition
	{
		// Token: 0x06015F94 RID: 90004 RVA: 0x006A3318 File Offset: 0x006A1718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
