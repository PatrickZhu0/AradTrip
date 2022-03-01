using System;

namespace behaviac
{
	// Token: 0x02003272 RID: 12914
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node10 : Assignment
	{
		// Token: 0x06014D62 RID: 85346 RVA: 0x00646CBC File Offset: 0x006450BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
