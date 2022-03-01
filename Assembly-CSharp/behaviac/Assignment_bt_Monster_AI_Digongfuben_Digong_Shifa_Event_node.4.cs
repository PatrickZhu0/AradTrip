using System;

namespace behaviac
{
	// Token: 0x02003262 RID: 12898
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node16 : Assignment
	{
		// Token: 0x06014D44 RID: 85316 RVA: 0x00646390 File Offset: 0x00644790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
