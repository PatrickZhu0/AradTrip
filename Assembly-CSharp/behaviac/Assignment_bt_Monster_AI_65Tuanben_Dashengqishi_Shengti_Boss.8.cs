using System;

namespace behaviac
{
	// Token: 0x02002E96 RID: 11926
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node19 : Assignment
	{
		// Token: 0x06014608 RID: 83464 RVA: 0x00620C68 File Offset: 0x0061F068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
