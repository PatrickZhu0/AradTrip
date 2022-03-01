using System;

namespace behaviac
{
	// Token: 0x020039A5 RID: 14757
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi2_Destination_node16 : Compute
	{
		// Token: 0x06015B1F RID: 88863 RVA: 0x0068D978 File Offset: 0x0068BD78
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
