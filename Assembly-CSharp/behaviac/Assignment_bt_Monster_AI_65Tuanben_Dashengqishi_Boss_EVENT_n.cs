using System;

namespace behaviac
{
	// Token: 0x02002DBE RID: 11710
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node10 : Assignment
	{
		// Token: 0x0601445C RID: 83036 RVA: 0x0061777C File Offset: 0x00615B7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
