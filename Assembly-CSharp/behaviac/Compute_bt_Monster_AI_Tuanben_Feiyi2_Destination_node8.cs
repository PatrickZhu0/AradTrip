using System;

namespace behaviac
{
	// Token: 0x020039A3 RID: 14755
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi2_Destination_node8 : Compute
	{
		// Token: 0x06015B1B RID: 88859 RVA: 0x0068D90C File Offset: 0x0068BD0C
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
