using System;

namespace behaviac
{
	// Token: 0x02003ABC RID: 15036
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Kuangsha_Action_node6 : Assignment
	{
		// Token: 0x06015D38 RID: 89400 RVA: 0x006984FC File Offset: 0x006968FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 0;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
