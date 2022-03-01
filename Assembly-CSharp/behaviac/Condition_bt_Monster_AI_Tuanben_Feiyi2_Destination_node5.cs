using System;

namespace behaviac
{
	// Token: 0x020039A1 RID: 14753
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node5 : Condition
	{
		// Token: 0x06015B17 RID: 88855 RVA: 0x0068D8AC File Offset: 0x0068BCAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 11;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
