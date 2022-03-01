using System;

namespace behaviac
{
	// Token: 0x0200327A RID: 12922
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node5 : Assignment
	{
		// Token: 0x06014D71 RID: 85361 RVA: 0x006471F0 File Offset: 0x006455F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
