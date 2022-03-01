using System;

namespace behaviac
{
	// Token: 0x02003EEB RID: 16107
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node5 : Assignment
	{
		// Token: 0x06016551 RID: 91473 RVA: 0x006C1A68 File Offset: 0x006BFE68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
