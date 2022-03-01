using System;

namespace behaviac
{
	// Token: 0x020039AC RID: 14764
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node0 : Condition
	{
		// Token: 0x06015B2C RID: 88876 RVA: 0x0068DF1C File Offset: 0x0068C31C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 10;
			bool flag = bianshen <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
