using System;

namespace behaviac
{
	// Token: 0x020039CC RID: 14796
	[GeneratedTypeMetaInfo]
	internal class Compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node4 : Compute
	{
		// Token: 0x06015B6A RID: 88938 RVA: 0x0068EEAC File Offset: 0x0068D2AC
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
