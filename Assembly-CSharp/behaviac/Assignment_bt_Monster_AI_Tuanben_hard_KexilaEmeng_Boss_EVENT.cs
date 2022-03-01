using System;

namespace behaviac
{
	// Token: 0x02003BF1 RID: 15345
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node91 : Assignment
	{
		// Token: 0x06015F90 RID: 90000 RVA: 0x006A32A4 File Offset: 0x006A16A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
