using System;

namespace behaviac
{
	// Token: 0x02003EF1 RID: 16113
	[GeneratedTypeMetaInfo]
	internal class Assignment_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node5 : Assignment
	{
		// Token: 0x0601655C RID: 91484 RVA: 0x006C1D84 File Offset: 0x006C0184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int bianshen = 1;
			((BTAgent)pAgent).bianshen = bianshen;
			return result;
		}
	}
}
