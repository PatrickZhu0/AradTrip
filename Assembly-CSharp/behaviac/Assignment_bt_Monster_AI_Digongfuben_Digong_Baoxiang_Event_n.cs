using System;

namespace behaviac
{
	// Token: 0x0200323E RID: 12862
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node5 : Assignment
	{
		// Token: 0x06014CFF RID: 85247 RVA: 0x0064533C File Offset: 0x0064373C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
