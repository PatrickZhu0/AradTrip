using System;

namespace behaviac
{
	// Token: 0x020039B1 RID: 14769
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node8 : Compute
	{
		// Token: 0x06015B36 RID: 88886 RVA: 0x0068E014 File Offset: 0x0068C414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			((BTAgent)pAgent).bianshen = bianshen + num;
			return result;
		}
	}
}
