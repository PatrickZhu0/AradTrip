using System;

namespace behaviac
{
	// Token: 0x02003BF9 RID: 15353
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node17 : Assignment
	{
		// Token: 0x06015FA0 RID: 90016 RVA: 0x006A3464 File Offset: 0x006A1864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
