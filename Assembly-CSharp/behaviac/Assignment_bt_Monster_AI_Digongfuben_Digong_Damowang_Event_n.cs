using System;

namespace behaviac
{
	// Token: 0x0200324A RID: 12874
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node5 : Assignment
	{
		// Token: 0x06014D16 RID: 85270 RVA: 0x0064592C File Offset: 0x00643D2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
