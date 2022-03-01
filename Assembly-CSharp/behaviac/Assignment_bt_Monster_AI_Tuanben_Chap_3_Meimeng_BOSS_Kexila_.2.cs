using System;

namespace behaviac
{
	// Token: 0x0200397C RID: 14716
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node14 : Assignment
	{
		// Token: 0x06015AD0 RID: 88784 RVA: 0x0068B9C0 File Offset: 0x00689DC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
