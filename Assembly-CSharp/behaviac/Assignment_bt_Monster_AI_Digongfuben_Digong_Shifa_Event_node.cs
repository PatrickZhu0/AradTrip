using System;

namespace behaviac
{
	// Token: 0x02003256 RID: 12886
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node2 : Assignment
	{
		// Token: 0x06014D2C RID: 85292 RVA: 0x0064609C File Offset: 0x0064449C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
