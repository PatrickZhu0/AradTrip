using System;

namespace behaviac
{
	// Token: 0x020039AE RID: 14766
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4 : Compute
	{
		// Token: 0x06015B30 RID: 88880 RVA: 0x0068DF80 File Offset: 0x0068C380
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
