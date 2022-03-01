using System;

namespace behaviac
{
	// Token: 0x02003CE4 RID: 15588
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node110 : Assignment
	{
		// Token: 0x0601616A RID: 90474 RVA: 0x006ACCF8 File Offset: 0x006AB0F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 2;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
