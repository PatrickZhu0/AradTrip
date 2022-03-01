using System;

namespace behaviac
{
	// Token: 0x0200325B RID: 12891
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node5 : Assignment
	{
		// Token: 0x06014D36 RID: 85302 RVA: 0x006461F4 File Offset: 0x006445F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
