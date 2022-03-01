using System;

namespace behaviac
{
	// Token: 0x020039B3 RID: 14771
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node16 : Compute
	{
		// Token: 0x06015B3A RID: 88890 RVA: 0x0068E080 File Offset: 0x0068C480
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
