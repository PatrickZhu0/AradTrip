using System;

namespace behaviac
{
	// Token: 0x02002D8B RID: 11659
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node134 : Assignment
	{
		// Token: 0x060143F8 RID: 82936 RVA: 0x006156D0 File Offset: 0x00613AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
