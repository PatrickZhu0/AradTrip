using System;

namespace behaviac
{
	// Token: 0x02003276 RID: 12918
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node13 : Assignment
	{
		// Token: 0x06014D69 RID: 85353 RVA: 0x00647110 File Offset: 0x00645510
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
