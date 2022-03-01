using System;

namespace behaviac
{
	// Token: 0x0200399E RID: 14750
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi2_Destination_node0 : Condition
	{
		// Token: 0x06015B11 RID: 88849 RVA: 0x0068D62C File Offset: 0x0068BA2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 10;
			bool flag = bianshen <= num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
