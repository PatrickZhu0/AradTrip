using System;

namespace behaviac
{
	// Token: 0x020039B2 RID: 14770
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node12 : Condition
	{
		// Token: 0x06015B38 RID: 88888 RVA: 0x0068E048 File Offset: 0x0068C448
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 12;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
