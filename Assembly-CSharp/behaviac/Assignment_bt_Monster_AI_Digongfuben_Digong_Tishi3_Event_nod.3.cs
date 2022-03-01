using System;

namespace behaviac
{
	// Token: 0x0200328A RID: 12938
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node10 : Assignment
	{
		// Token: 0x06014D90 RID: 85392 RVA: 0x00647904 File Offset: 0x00645D04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
