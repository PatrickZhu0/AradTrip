using System;

namespace behaviac
{
	// Token: 0x02003CEC RID: 15596
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node117 : Assignment
	{
		// Token: 0x0601617A RID: 90490 RVA: 0x006ACED8 File Offset: 0x006AB2D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 4;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
