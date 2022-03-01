using System;

namespace behaviac
{
	// Token: 0x0200328E RID: 12942
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node13 : Assignment
	{
		// Token: 0x06014D97 RID: 85399 RVA: 0x00647D58 File Offset: 0x00646158
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
