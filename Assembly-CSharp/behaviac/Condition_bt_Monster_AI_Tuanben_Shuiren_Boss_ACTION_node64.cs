using System;

namespace behaviac
{
	// Token: 0x02003B43 RID: 15171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node64 : Condition
	{
		// Token: 0x06015E3C RID: 89660 RVA: 0x0069D468 File Offset: 0x0069B868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int bianshen = ((BTAgent)pAgent).bianshen;
			int num = 1;
			bool flag = bianshen == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}
