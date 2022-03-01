using System;

namespace behaviac
{
	// Token: 0x020039C2 RID: 14786
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node12 : Condition
	{
		// Token: 0x06015B57 RID: 88919 RVA: 0x0068E86C File Offset: 0x0068CC6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 12;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
