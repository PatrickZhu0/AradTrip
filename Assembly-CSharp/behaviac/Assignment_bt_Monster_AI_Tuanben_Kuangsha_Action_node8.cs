using System;

namespace behaviac
{
	// Token: 0x02003ABF RID: 15039
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Tuanben_Kuangsha_Action_node8 : Assignment
	{
		// Token: 0x06015D3E RID: 89406 RVA: 0x00698598 File Offset: 0x00696998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
