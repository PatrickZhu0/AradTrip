using System;

namespace behaviac
{
	// Token: 0x020039A4 RID: 14756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node12 : Condition
	{
		// Token: 0x06015B1D RID: 88861 RVA: 0x0068D940 File Offset: 0x0068BD40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 12;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
