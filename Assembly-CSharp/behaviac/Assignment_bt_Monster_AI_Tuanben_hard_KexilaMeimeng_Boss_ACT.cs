using System;

namespace behaviac
{
	// Token: 0x02003C13 RID: 15379
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node23 : Assignment
	{
		// Token: 0x06015FD2 RID: 90066 RVA: 0x006A4E04 File Offset: 0x006A3204
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
