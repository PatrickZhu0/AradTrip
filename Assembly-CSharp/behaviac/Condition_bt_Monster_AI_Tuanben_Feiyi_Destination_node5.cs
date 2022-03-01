using System;

namespace behaviac
{
	// Token: 0x020039BF RID: 14783
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node5 : Condition
	{
		// Token: 0x06015B51 RID: 88913 RVA: 0x0068E7D8 File Offset: 0x0068CBD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 11;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
