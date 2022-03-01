using System;

namespace behaviac
{
	// Token: 0x0200326A RID: 12906
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node13 : Assignment
	{
		// Token: 0x06014D52 RID: 85330 RVA: 0x00646AEC File Offset: 0x00644EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
