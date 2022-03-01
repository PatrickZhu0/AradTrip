using System;

namespace behaviac
{
	// Token: 0x02002E02 RID: 11778
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node98 : Assignment
	{
		// Token: 0x060144E2 RID: 83170 RVA: 0x006195A8 File Offset: 0x006179A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
