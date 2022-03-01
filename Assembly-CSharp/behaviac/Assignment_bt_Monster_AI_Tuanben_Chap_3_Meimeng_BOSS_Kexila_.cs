using System;

namespace behaviac
{
	// Token: 0x02003974 RID: 14708
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node20 : Assignment
	{
		// Token: 0x06015AC0 RID: 88768 RVA: 0x0068B744 File Offset: 0x00689B44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
