using System;

namespace behaviac
{
	// Token: 0x0200327E RID: 12926
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node10 : Assignment
	{
		// Token: 0x06014D79 RID: 85369 RVA: 0x006472E0 File Offset: 0x006456E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
