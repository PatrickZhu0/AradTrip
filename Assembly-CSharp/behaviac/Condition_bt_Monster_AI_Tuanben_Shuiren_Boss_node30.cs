using System;

namespace behaviac
{
	// Token: 0x02003B18 RID: 15128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node30 : Condition
	{
		// Token: 0x06015DE9 RID: 89577 RVA: 0x0069BC04 File Offset: 0x0069A004
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 0;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
