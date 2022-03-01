using System;

namespace behaviac
{
	// Token: 0x0200326E RID: 12910
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node5 : Assignment
	{
		// Token: 0x06014D5A RID: 85338 RVA: 0x00646BCC File Offset: 0x00644FCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
