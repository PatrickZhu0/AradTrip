using System;

namespace behaviac
{
	// Token: 0x02003A9E RID: 15006
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node116 : Assignment
	{
		// Token: 0x06015D01 RID: 89345 RVA: 0x00696EB4 File Offset: 0x006952B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
