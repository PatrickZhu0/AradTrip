using System;

namespace behaviac
{
	// Token: 0x02003D83 RID: 15747
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node42 : Assignment
	{
		// Token: 0x0601629C RID: 90780 RVA: 0x006B2FF4 File Offset: 0x006B13F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 5;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
