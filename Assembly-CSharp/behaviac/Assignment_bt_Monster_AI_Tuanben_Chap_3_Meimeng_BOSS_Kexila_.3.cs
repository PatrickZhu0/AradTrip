using System;

namespace behaviac
{
	// Token: 0x02003980 RID: 14720
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node8 : Assignment
	{
		// Token: 0x06015AD8 RID: 88792 RVA: 0x0068BACC File Offset: 0x00689ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
