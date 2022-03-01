using System;

namespace behaviac
{
	// Token: 0x02003EFD RID: 16125
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node5 : Assignment
	{
		// Token: 0x06016572 RID: 91506 RVA: 0x006C23BC File Offset: 0x006C07BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
