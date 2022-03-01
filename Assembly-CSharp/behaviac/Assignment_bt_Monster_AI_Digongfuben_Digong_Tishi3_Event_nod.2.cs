using System;

namespace behaviac
{
	// Token: 0x02003286 RID: 12934
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node5 : Assignment
	{
		// Token: 0x06014D88 RID: 85384 RVA: 0x00647814 File Offset: 0x00645C14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
