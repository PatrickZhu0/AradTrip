using System;

namespace behaviac
{
	// Token: 0x02003282 RID: 12930
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node13 : Assignment
	{
		// Token: 0x06014D80 RID: 85376 RVA: 0x00647734 File Offset: 0x00645B34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
