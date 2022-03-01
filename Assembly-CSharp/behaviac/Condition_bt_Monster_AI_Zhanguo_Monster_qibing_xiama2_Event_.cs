using System;

namespace behaviac
{
	// Token: 0x02003EE7 RID: 16103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node4 : Condition
	{
		// Token: 0x06016549 RID: 91465 RVA: 0x006C18DC File Offset: 0x006BFCDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
