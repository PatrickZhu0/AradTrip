using System;

namespace behaviac
{
	// Token: 0x02003D44 RID: 15684
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node67 : Assignment
	{
		// Token: 0x0601621F RID: 90655 RVA: 0x006B0A08 File Offset: 0x006AEE08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 3;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
