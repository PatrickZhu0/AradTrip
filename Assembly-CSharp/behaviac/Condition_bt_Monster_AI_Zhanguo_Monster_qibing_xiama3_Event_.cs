using System;

namespace behaviac
{
	// Token: 0x02003EED RID: 16109
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node4 : Condition
	{
		// Token: 0x06016554 RID: 91476 RVA: 0x006C1BF8 File Offset: 0x006BFFF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
