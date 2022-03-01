using System;

namespace behaviac
{
	// Token: 0x0200329A RID: 12954
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Xianjing_Event_node5 : Assignment
	{
		// Token: 0x06014DAE RID: 85422 RVA: 0x00648384 File Offset: 0x00646784
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
