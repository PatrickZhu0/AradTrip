using System;

namespace behaviac
{
	// Token: 0x02003988 RID: 14728
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node30 : Assignment
	{
		// Token: 0x06015AE8 RID: 88808 RVA: 0x0068BCE4 File Offset: 0x0068A0E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 5;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
