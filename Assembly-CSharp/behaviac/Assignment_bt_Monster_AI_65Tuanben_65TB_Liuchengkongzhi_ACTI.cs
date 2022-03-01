using System;

namespace behaviac
{
	// Token: 0x02002BBD RID: 11197
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3 : Assignment
	{
		// Token: 0x0601407F RID: 82047 RVA: 0x006042B8 File Offset: 0x006026B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
