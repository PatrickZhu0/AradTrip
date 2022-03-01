using System;

namespace behaviac
{
	// Token: 0x02003984 RID: 14724
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node12 : Assignment
	{
		// Token: 0x06015AE0 RID: 88800 RVA: 0x0068BBD8 File Offset: 0x00689FD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
