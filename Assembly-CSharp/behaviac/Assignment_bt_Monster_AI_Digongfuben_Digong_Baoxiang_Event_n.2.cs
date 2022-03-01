using System;

namespace behaviac
{
	// Token: 0x02003242 RID: 12866
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node13 : Assignment
	{
		// Token: 0x06014D07 RID: 85255 RVA: 0x00645430 File Offset: 0x00643830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
