using System;

namespace behaviac
{
	// Token: 0x02003BF5 RID: 15349
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node10 : Assignment
	{
		// Token: 0x06015F98 RID: 90008 RVA: 0x006A3384 File Offset: 0x006A1784
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
