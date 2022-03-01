using System;

namespace behaviac
{
	// Token: 0x02003B38 RID: 15160
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node25 : Condition
	{
		// Token: 0x06015E29 RID: 89641 RVA: 0x0069C744 File Offset: 0x0069AB44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 8;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
